using GM.Application.Configuration;
using GM.Infrastructure.InfraCore.Data;
using GM.WebUI.WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace GM.WebUI.WebApp
{
    public class Program
    {
        static IWebHostEnvironment _Env;

        public static void Main(string[] args)
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
                webBuilder.UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) => 
                {
                    _Env = hostingContext.HostingEnvironment;
                    BuildConfig.Build(config, _Env.EnvironmentName);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();  // NLog: setup NLog for Dependency injection
            });
    }
}
