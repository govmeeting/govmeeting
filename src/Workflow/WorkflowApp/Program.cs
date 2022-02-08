using GM.Application.Configuration;
using GM.Application.ProcessRecording;
using GM.Application.ProcessTranscript;
//using GM.DatabaseRepositories;
//using GM.DatabaseRepositories_Stub;
using GM.Infrastructure.InfraCore.Data;
using GM.Infrastructure.FileDataRepositories;
////using GM.Infrastructure.InfraCore.Data_Stub;
using GM.Infrastructure.GetOnlineFiles;
using GM.Infrastructure.GoogleCloud;
using GM.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;


namespace GM.WorkflowApp
{
    /* Eventually This may become part of WebApp. It is in a separate proceess
     * for development. We want to start it in the same way that WebApp will start it.
     * So we use dependency injection with providers for logging, configuration and other services.
     */

    public class Program
    {
        public static void Main()
        {
            // https://pioneercode.com/post/dependency-injection-logging-and-configuration-in-a-dot-net-core-console-app

            // Google Cloud libraries automatically use the environment variable GOOGLE_APPLICATION_CREDENTIALS
            // to authenticate to Google Cloud. Here we set this variable to the path of the credentials file,
            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            //var m = serviceProvider.GetService<IMeetingRepository>();

            var config = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            string testfilesPath = config.TestdataPath;
            string datafilesPath = config.DatafilesPath;

            var logger = serviceProvider.GetService<ILogger<Program>>();

            //StorageClient storageClient = StorageClient.Create();

            // Copy test data to Datafiles
            if (config.InitializeWithTestData) {
                string err = InitializeFileTestData.CopyTestData(testfilesPath, datafilesPath, config.DeleteProcessingFolderOnStartup);
                if (err != null)
                {
                    logger.LogError(err);
                }
            }

            // entry to run app
            serviceProvider.GetService<WorkflowController>().Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // add configured instance of logging
            //services.AddSingleton(new LoggerFactory()
            //    .AddConsole()
            //    .AddDebug());

            // add logging
            services.AddLogging();

            // build configuration
            var config = new ConfigurationBuilder();
            BuildConfig.Build(config, environmentName);

            var configuration = config.Build();
            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify paths to be full paths.
                myOptions.DatafilesPath = GetFullPathOnEitherDevOrProdSystem(myOptions.DatafilesPath);
                myOptions.TestdataPath = GetFullPathOnEitherDevOrProdSystem(myOptions.TestdataPath);
                myOptions.GoogleApplicationCredentials = GetFullPathOnEitherDevOrProdSystem(myOptions.GoogleApplicationCredentials);
            });

            // add services
            //services.AddTransient<IOptions<AppSettings>>();
            services.AddTransient<ApplicationDbContext>();
            ////services.AddTransient<IDBOperations, DBOperationsStub>();
            services.AddTransient<IRecordingProcess, RecordingProcess>();
            services.AddTransient<TranscribeAudio>();
            services.AddTransient<ITranscriptProcess, TranscriptProcess>();
            //services.AddTransient<ILoadTranscript, LoadTranscript_Stub>();
            services.AddTransient<IFileRepository, FileRepository>();


            // services.AddTransient<IMeetingRepository, MeetingRepository_Stub>();
            // services.AddTransient<IGovbodyRepository, GovbodyRepository_Stub>();
            //services.AddSingleton<IMeetingRepository, MeetingRepository_Stub>();
            //services.AddSingleton<IGovbodyRepository, GovbodyRepository_Stub>();
            //services.AddSingleton<IGovLocationRepository, GovLocationRepository_Stub>();
            //services.AddSingleton<IGovLocationRepository, GovLocationRepository_Stub>();
            services.AddSingleton<IRetrieveNewFiles, RetrieveNewFiles>();

            // TODO make singletons
            services.AddTransient<WF1_Retrieve>();
            services.AddTransient<WF2_Process>();
            services.AddTransient<WF3_Transcribe>();
            services.AddTransient<WF4_Tag>();
            services.AddTransient<WF5_Edit>();
            services.AddTransient<WF6_View>();
            services.AddTransient<WF7_Load>();
            services.AddTransient<WF8_Alert>();

            // add app
            services.AddTransient<WorkflowController>();
        }
        
        private static string GetFullPathOnEitherDevOrProdSystem(string folder)
        {
            if (Path.IsPathRooted(folder))
            {
                return folder;
            }
            return GMFileAccess.GetSolutionSiblingFolder(folder);
        }

    }
}
