using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GM.Configuration;
//using GM.ProcessRecordings;
using Microsoft.Extensions.Options;
using GM.GoogleCLoud;
using GM.Utilities;

namespace GM.Utilities.Translate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();


            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            serviceProvider.GetService<TranslateDocs>().Run(args);

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TranslateInCloud>();
            services.AddTransient<TranslateDocs>();

        }
    }
}
