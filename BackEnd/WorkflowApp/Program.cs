using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using GM.Configuration;
using GM.ProcessRecording;
using GM.GoogleCLoud;
using GM.ProcessTranscript;
using GM.FileDataRepositories;
using GM.DatabaseRepositories;
using GM.LoadDatabase;
using GM.DatabaseAccess;
using Microsoft.Extensions.Options;

namespace GM.Workflow
{
    /* Eventually This may become part of WebApp. It is in a separate proceess
     * for development. We want to start it in the same way that WebApp will start it.
     * So we use dependency injection with providers for logging, configuration and other services.
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            // https://pioneercode.com/post/dependency-injection-logging-and-configuration-in-a-dot-net-core-console-app

            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            //var m = serviceProvider.GetService<IMeetingRepository>();

            var config = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            string testfilesPath = config.TestfilesPath;
            string datafilesPath = config.DatafilesPath;

            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Copy test data to Datafiles
            string err = InitializeFileTestData.CopyTestData(testfilesPath, datafilesPath, config.DeleteProcessingFolderOnStartup);
            if (err != null)
            {
                logger.LogError(err);
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
                myOptions.TestfilesPath = GMFileAccess.GetProjectSiblingFolder(myOptions.TestfilesPath);
                myOptions.GoogleApplicationCredentials = GMFileAccess.GetProjectSiblingFolder(myOptions.GoogleApplicationCredentials);
                // myOptions.DatafilesPath = GMFileAccess.GetFullPath(myOptions.DatafilesPath);
                // myOptions.TestfilesPath = GMFileAccess.GetFullPath(myOptions.TestfilesPath);
                // myOptions.GoogleApplicationCredentials = GMFileAccess.GetFullPath(myOptions.GoogleApplicationCredentials);
            });

            // add services
            //services.AddTransient<IOptions<AppSettings>>();
            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<dBOperations>();
            services.AddTransient<RecordingProcess>();
            services.AddTransient<TranscribeAudio>();
            services.AddTransient<TranscriptProcess>();
            //services.AddTransient<ILoadTranscript, LoadTranscript_Stub>();
            services.AddTransient<AddtagsRepository>();
            services.AddTransient<FixasrRepository>();

            // services.AddTransient<IMeetingRepository, MeetingRepository_Stub>();
            // services.AddTransient<IGovBodyRepository, GovBodyRepository_Stub>();
            services.AddSingleton<IMeetingRepository, MeetingRepository_Stub>();
            services.AddSingleton<IGovBodyRepository, GovBodyRepository_Stub>();
            
            services.AddTransient<WF_RetrieveOnlineFiles>();
            services.AddTransient<WF_ProcessReceivedFiles>();
            services.AddTransient<WF_ProcessRecordings>();
            services.AddTransient<WF_ProcessTranscripts>();
            services.AddTransient<WF_ProcessTagged>();
            services.AddTransient<WF_ProcessProofread>();
            services.AddTransient<WF_LoadDatabase>();

            // add app
            services.AddTransient<WorkflowController>();
        }
    }
}
