using Microsoft.Extensions.DependencyInjection;
using GM.Application.Configuration;

namespace GM.Utilities.TranslateText
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
