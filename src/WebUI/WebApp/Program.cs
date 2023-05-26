using GM.Application.Configuration;
using GM.Infrastructure.InfraCore.Data;
using GM.WebUI.WebApp.Services;
using GM.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;

namespace GM.WebUI.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dateString = DateTime.Now.ToString("yyy-MM-dd");
            NLog.Common.InternalLogger.LogFile = string.Format("C:\\GOVMEETING\\LOGS\\nlog-internal-{0}.log", dateString);
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("=== Start of Main ==="); // This first log message will not appear in the log file, only in the console.

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                ConfigureLoggingService(builder);

                var startup = new GM.WebUI.WebApp.Startup(builder.Configuration, builder.Environment, logger);

                logger.Debug("=====================");  // First log message in log file.
                logger.Debug("Call ConfigureServices");
                
                startup.ConfigureServices(builder.Services);
                var app = builder.Build();

                logger.Debug("Call Configure");
                startup.Configure(app);

                app.Run();
            }
            catch (Exception exception)
            {
                // NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                logger.Debug("=====================");  // Last log message in log file.
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                logger.Debug("LogManager shutdown");
                NLog.LogManager.Shutdown();
            }
        }

        public static void ConfigureLoggingService(WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            // Set a variable in the gdc which is be used in NLog.config for the
            // base path of our app: ${gdc:item=appbasepath} 
            string logfilesPath = builder.Configuration["Logging:LogfilesPath"];
            if (builder.Environment.IsDevelopment())
            {
                logfilesPath = GMFileAccess.GetSolutionSiblingFolder(logfilesPath);
            }
            GlobalDiagnosticsContext.Set("logfilesPath", logfilesPath);
        }

    }
}

namespace GM.WebUI.WebApp
{
    public class XProgram
    {
        static IWebHostEnvironment _Env;

        public static void XMain(string[] args)
        {
            Console.WriteLine("=====================In Main====================");
            var host = CreateHostBuilder(args).Build();

            // If development, migrate and seed the database.
            // Migrate() also creates the database if it does not exist.
            if (_Env.IsDevelopment() || _Env.IsStaging() || _Env.EnvironmentName == "StagingLocal")
            {
                using (var scope = host.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.Migrate();

                    var seedDatabase = scope.ServiceProvider.GetRequiredService<ISeedDatabase>();
                    seedDatabase.Seed();

                    // This auth code needs re-work.
                    //var seedDbUsers = scope.ServiceProvider.GetRequiredService<ISeedAuth>();
                    //seedDbUsers.Seed();
                }
            }

            host.Run();
        }

        /*
        CreateDefaultBuilder automatically includes the appropriate appsettings.Environment.json.
        Set the ASPNETCORE_ENVIRONMENT environment variable to "Development", "Production", etc.
        For VsCode this can be set in Properties/launchSettings.json.
        For Visual Studio, use: Project > Properties > Debug > Environment Variables.
        */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<XStartup>()
                .ConfigureAppConfiguration((hostingContext, config) => 
                {
                    _Env = hostingContext.HostingEnvironment;
                    BuildConfig.Build(config, _Env.EnvironmentName);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();  // NLog: setup NLog for Dependency injection
            });
    }
}
