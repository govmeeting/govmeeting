using GM.Application.Configuration;
using GM.Infrastructure.InfraCore.Data;
using GM.WebUI.WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace GM.WebUI.WebApp
{
    public class Program
    {
        static IWebHostEnvironment _Env;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // If development, migrate and seed the database.
            // Migrate() also creates the database if it does not exist.
            if (_Env.IsDevelopment())
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
