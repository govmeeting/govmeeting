using GM.Application.Configuration;
using GM.Application.ProcessRecording;
using GM.Application.ProcessTranscript;
//using GM.DatabaseRepositories;
//using GM.DatabaseRepositories_Stub;
using GM.DatabaseAccess;
using GM.Infrastructure.FileDataRepositories;
////using GM.DatabaseAccess_Stub;
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

            string secrets = GMFileAccess.GetSolutionSiblingFolder("SECRETS");
            string credentialsFilePath = Path.Combine(secrets, "TranscribeAudio.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);

            //StorageClient storageClient = StorageClient.Create();
            //string secrets = GMFileAccess.FindParentFolderWithName("SECRETS");


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

            // Google Cloud libraries automatically use the environment variable GOOGLE_APPLICATION_CREDENTIALS
            // to authenticate to Google Cloud. Here we set this variable to the path of the credentials file,
            // which is defined in app.settings.json.
            //string credentialsFilePath = config.GoogleApplicationCredentials;
            //if (!File.Exists(credentialsFilePath)){
            //    logger.LogError("Credentials File does not exists: ${credentialsFilePath}");
            //}
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);

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

            //// appsettings.json is copied to the output folder during the build.
            //// Otherwise, we would need to set appsettingsdir as follows:
            //// string appsettingsdir = Directory.GetCurrentDirectory() + @"\..\..\..";

            //// Location of appsettings.json
            //string appsettingsdir = Directory.GetCurrentDirectory();

            //string devSettingFile = $"appsettings.{environmentName}.json";
            //// Find path to the SECRETS folder
            //string secrets = GMFileAccess.GetSolutionSiblingFolder("SECRETS");
            //// If it exists look there for environment settings file.
            //if (secrets != null)
            //{
            //    devSettingFile = Path.Combine(secrets, $"appsettings.{environmentName}.json");
            //}

            //var configuration = new ConfigurationBuilder()
            //    // TODO - The following path will only work in development.
            //    // It isn't yet decided how WorkflowApp will run in production.
            //    // Will it be a separate .EXE or a .LIB loaded by WebApp?
            //    .SetBasePath(appsettingsdir)
            //    .AddJsonFile("appsettings.json", false)
            //    .AddJsonFile(devSettingFile, optional: true)
            //    .Build();

            var configuration = config.Build();
            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify paths to be full paths.
                myOptions.DatafilesPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.DatafilesPath);
                myOptions.TestdataPath = GMFileAccess.GetSolutionSiblingFolder(myOptions.TestdataPath);
                myOptions.GoogleApplicationCredentials = GMFileAccess.GetSolutionSiblingFolder(myOptions.GoogleApplicationCredentials);
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
    }
}
