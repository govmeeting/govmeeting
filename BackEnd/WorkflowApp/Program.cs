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

            //var a = serviceProvider.GetService<RetrieveOnlineFiles>();
            //var b = serviceProvider.GetService<RetrieveOnlineFiles>();
            //var c = serviceProvider.GetService<ProcessIncomingFiles>();
            //var d = serviceProvider.GetService<RecordingProcess>();
            //var e = serviceProvider.GetService<TranscribeAudio>();
            //var f = serviceProvider.GetService<TranscriptProcess>();
            //var g = serviceProvider.GetService<ILoadTranscript>();
            //var h = serviceProvider.GetService<ProcessTagged>();
            //var i = serviceProvider.GetService<ProcessFixedAsr>();
            //var j = serviceProvider.GetService<AddtagsRepository>();
            //var k = serviceProvider.GetService<FixasrRepository>();
            //var l = serviceProvider.GetService<MeetingFolder>();

            var m = serviceProvider.GetService<IOptions<AppSettings>>();


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
            string appsettingsdir = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                // TODO - The following path will only work in development.
                // It isn't yet decided how Workflow_App will be run in production.
                // Will it be a separate .EXE or a .LIB loaded by WebApp?
                // TODO ** Move environment specific appsettings to build folder
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .SetBasePath(appsettingsdir)
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
            //services.AddTransient<IOptions<AppSettings>>();
            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<dBOperations>();
            services.AddTransient<RetrieveOnlineFiles>();
            services.AddTransient<ProcessIncomingFiles>();
            services.AddTransient<RecordingProcess>();
            services.AddTransient<TranscribeAudio>();
            services.AddTransient<TranscriptProcess>();
            services.AddTransient<ILoadTranscript, LoadTranscript_Stub>();
            services.AddTransient<ProcessTagged>();
            services.AddTransient<ProcessFixedAsr>();
            services.AddTransient<AddtagsRepository>();
            services.AddTransient<FixasrRepository>();
            services.AddTransient<MeetingFolder>();
            services.AddTransient<IMeetingRepository, MeetingRepository_Stub>();
            services.AddTransient<IGovBodyRepository, GovBodyRepository_Stub>();

            // add app
            services.AddTransient<WorkflowController>();
        }
    }
}
