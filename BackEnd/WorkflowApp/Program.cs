using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using GM.Configuration;
using GM.ProcessRecording;
using GM.GoogleCloud;
using GM.ProcessTranscript;
using GM.FileDataRepositories;
using GM.DatabaseRepositories;
using GM.DatabaseRepositories_Stub;
using GM.DatabaseAccess;
using Microsoft.Extensions.Options;
using Google.Cloud.Storage.V1;
using GM.Utilities;
using GM.DatabaseAccess_Stub;

namespace GM.Workflow
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

            string credentialsFilePath = @"C:\GOVMEETING\SECRETS\TranscribeAudio.json";
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
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());

            // add logging
            services.AddLogging();

            // build configuration

            // appsettings.json is copied to the output folder during the build.
            // Otherwise, we would need to set appsettingsdir as follows:
            // string appsettingsdir = Directory.GetCurrentDirectory() + @"\..\..\..";

            // Location of appsettings.json
            string appsettingsdir = Directory.GetCurrentDirectory();

            string devSettingFile = $"appsettings.{environmentName}.json";
            // Find path to the SECRETS folder
            string secrets = GMFileAccess.FindParentFolderWithName("SECRETS");
            // If it exists look there for environment settings file.
            if (secrets != null)
            {
                devSettingFile = Path.Combine(secrets, $"appsettings.{environmentName}.json");
            }

            var configuration = new ConfigurationBuilder()
                // TODO - The following path will only work in development.
                // It isn't yet decided how WorkflowApp will run in production.
                // Will it be a separate .EXE or a .LIB loaded by WebApp?
                .SetBasePath(appsettingsdir)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile(devSettingFile, optional: true)
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify paths to be full paths.
                myOptions.DatafilesPath = GMFileAccess.GetProjectSiblingFolder(myOptions.DatafilesPath);
                myOptions.TestdataPath = GMFileAccess.GetProjectSiblingFolder(myOptions.TestdataPath);
                myOptions.GoogleApplicationCredentials = GMFileAccess.GetProjectSiblingFolder(myOptions.GoogleApplicationCredentials);
            });

            // add services
            //services.AddTransient<IOptions<AppSettings>>();
            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<IDBOperations, DBOperationsStub>();
            services.AddTransient<RecordingProcess>();
            services.AddTransient<TranscribeAudio>();
            services.AddTransient<TranscriptProcess>();
            //services.AddTransient<ILoadTranscript, LoadTranscript_Stub>();
            services.AddTransient<IFileRepository, FileRepository>();


            // services.AddTransient<IMeetingRepository, MeetingRepository_Stub>();
            // services.AddTransient<IGovBodyRepository, GovBodyRepository_Stub>();
            services.AddSingleton<IMeetingRepository, MeetingRepository_Stub>();
            services.AddSingleton<IGovBodyRepository, GovBodyRepository_Stub>();
            services.AddSingleton<IGovLocationRepository, GovLocationRepository_Stub>();

            // TODO make singletons
            services.AddTransient<WF1_RetrieveOnlineFiles>();
            services.AddTransient<WF2_ProcessTranscripts>();
            services.AddTransient<WF3_TranscribeRecordings>();
            services.AddTransient<WF4_TagTranscripts>();
            services.AddTransient<WF5_EditTranscriptions>();
            services.AddTransient<WF6_ViewMeetings>();
            services.AddTransient<WF7_LoadDatabase>();
            services.AddTransient<WF8_SendAlerts>();

            // add app
            services.AddTransient<WorkflowController>();
        }
    }
}
