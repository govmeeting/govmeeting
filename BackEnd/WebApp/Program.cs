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

namespace GM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string en = Environment.CurrentDirectory;
            //string dr = Directory.GetCurrentDirectory();
            //string ad = AppDomain.CurrentDomain.BaseDirectory;
            //string sa = System.AppContext.BaseDirectory;
            //string rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


            // NLog: setup the logger first to catch all errors
            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                //BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    if (env.IsDevelopment())
                    {
                        // If development, include _SECRETS/appsettings.Development.json in the configuration.
                        // This file contains the keys for using reCaptcha and Google external authorization.
                        string devSettingFile = Environment.CurrentDirectory + @"\..\..\..\..\_SECRETS\" + $"appsettings.{env.EnvironmentName}.json";
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
                //.Build();
    
    }
}
