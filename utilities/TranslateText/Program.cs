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

            // Get appsettings
            //var config = serviceProvider.GetService<IOptions<AppSettings>>().Value;

            // Find path to the SECRETS folder
            string credentialsFilePath;
            string secrets = GMFileAccess.FindParentFolderWithName("SECRETS");
            // If it exists look there for Google Application Credentials.
            if (secrets != null)
            {
                credentialsFilePath = Path.Combine(secrets, "TranscribeAudio.json");
            }
            else
            {
                Console.WriteLine("ERROR: Can't located Google Application Credentials");
                return;
            }

            // Google Cloud libraries automatically use the environment variable GOOGLE_APPLICATION_CREDENTIALS
            // to authenticate to Google Cloud. Here we set this variable to the path of the credentials file,
            // which is defined in appsettings.json in the SECRETS folder
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);

            serviceProvider.GetService<TranslateDocs>().Run(args);

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IOptions<AppSettings>>();
            services.AddTransient<TranslateInCloud>();
            services.AddTransient<TranslateDocs>();

        }
    }
}
