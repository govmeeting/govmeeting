using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using GM.WebApp.Services;
using Microsoft.Extensions.DependencyInjection;
using GM.DatabaseAccess;

namespace GM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
            .Build()
            //.MigrateDatabase()
            .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // CreateDefaultBuilder actually adds in both appsettings.json and the appsettings for our current environment.
            // But our appsettings.Development.json is in the secrets folder, so we need to specifically add it here.
            // In production, we will copy appsettings.Production.json from the secrets folder to to the app folder.
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    if (env.IsDevelopment())
                    {
                        // If development, include _SECRETS/appsettings.Development.json in the configuration.
                        // This file contains the keys for using reCaptcha and Google external authorization.
                        string devSettingFile = Environment.CurrentDirectory + @"\..\..\..\_SECRETS\" + $"appsettings.{env.EnvironmentName}.json";
                        if (File.Exists(devSettingFile))
                        {
                            config.AddJsonFile(devSettingFile, optional: true, reloadOnChange: true);
                            //config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                        }
                    }
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();  // NLog: setup NLog for Dependency injection
    
    }
}
