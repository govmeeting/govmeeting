using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using GM.Configuration;
using GM.ProcessRecording;
using GM.ProcessTranscript;
using GM.FileDataRepositories;
using GM.DatabaseRepositories;
using GM.LoadDatabase;
using GM.ProcessRecordings;

namespace GM.WorkFlow
{
    /* Eventually This will become part of WebApp. It is in a separate proceess
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

            // entry to run app
            serviceProvider.GetService<WorkFlowController>().Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // add configured instance of logging
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());

            // add logging
            services.AddLogging();

            // build configuration
            var configuration = new ConfigurationBuilder()
                // TODO - The following path will only work in development.
                // It isn't yet decided how Workflow_App will be run in production.
                // Will it be a separate .EXE or a .LIB loaded by Web_App?
                .SetBasePath(Directory.GetCurrentDirectory() + @"\..\..\..")
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(myOptions =>
            {
                // Modify paths to be full paths.
                myOptions.DatafilesPath = GMFileAccess.GetFullPath(myOptions.DatafilesPath);
                myOptions.TestfilesPath = GMFileAccess.GetFullPath(myOptions.TestfilesPath);
                myOptions.GoogleApplicationCredentials = GMFileAccess.GetFullPath(myOptions.GoogleApplicationCredentials);
            });

            // add services
            services.AddTransient<RetrieveOnlineFiles>();
            services.AddTransient<ProcessIncomingFiles>();
            services.AddTransient<RecordingProcess>();
            services.AddTransient<TranscribeAudio>();
            services.AddTransient<TranscriptProcess>();
            services.AddTransient<LoadTranscript>();
            services.AddTransient<ProcessTagged>();
            services.AddTransient<ProcessFixedAsr>();
            services.AddTransient<AddtagsRepository>();
            services.AddTransient<FixasrRepository>();
            services.AddTransient<MeetingFolder>();
            services.AddTransient<IMeetingRepository, MeetingRepository>();
            services.AddTransient<IGovBodyRepository, GovBodyRepository>();

            // add app
            services.AddTransient<WorkFlowController>();
        }
    }
}
