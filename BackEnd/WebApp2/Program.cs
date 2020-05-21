using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using GM.FileDataRepositories;
using GM.Utilities;


namespace GM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // CreateDefaultBuilder would normally add both appsettings.json and the appsettings for our current environment.
        // But our appsettings.Development.json is in the secrets folder, so we need to specifically add it here.
        // When we deploy to production, we upload appsettings.Production.json from the secrets folder.
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    if (env.IsDevelopment())
                    {
                        // If development, include SECRETS/appsettings.Development.json in the configuration.
                        // This file contains the keys for using reCaptcha and Google external authorization.
                        string secretsFolder = GMFileAccess.GetProjectSiblingFolder("SECRETS");
                        string devSettingFile = secretsFolder + "/" + $"appsettings.{env.EnvironmentName}.json";
                        if (File.Exists(devSettingFile))
                        {
                            config.AddJsonFile(devSettingFile, optional: true, reloadOnChange: true);
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