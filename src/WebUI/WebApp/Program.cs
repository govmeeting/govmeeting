using GM.Application.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.Collections.Generic;

namespace GM.WebUI.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // This is for testing how to query for ancestors
            //IEnumerable<District> ancestors =QueryDistricts();

            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) => 
                {
                    var env = hostingContext.HostingEnvironment;
                    BuildConfig.Build(config, env.EnvironmentName);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();  // NLog: setup NLog for Dependency injection
            });

        public static IEnumerable<District> QueryDistricts()
        {
            List<District> districts = new List<District>();
            districts.Add(new District() { Id = 0, Parent = null });
            districts.Add(new District() { Id = 1, Parent = null });
            districts.Add(new District() { Id = 2, Parent = districts[0] });
            districts.Add(new District() { Id = 3, Parent = null });
            districts.Add(new District() { Id = 4, Parent = districts[2] });
            districts.Add(new District() { Id = 5, Parent = null });

            IEnumerable<District> ancestors = districts[4].Ancestors;
            return ancestors;
        }
    }


    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public District Parent { get; set; }
        public IEnumerable<District> Ancestors
        {
            get
            {
                District parent = Parent;
                while (parent != null)
                {
                    yield return parent;
                    parent = parent.Parent;
                }
            }
        }

    }
}
