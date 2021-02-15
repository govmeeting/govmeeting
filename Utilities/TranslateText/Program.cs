using Microsoft.Extensions.DependencyInjection;

namespace GM.Utilities.TranslateText
{
    public class Program
    {
        private static string[] allDocuments = { "overview1", "overview2", "workflow", "project-status", "setup", "sys-design", "dev-notes", "database" };
        private static string[] allLanguages = { "de", "es", "fr", "it", "fi", "ar", "sw", "zh", "pt", "bn", "hi" };

        // Edit these arrays as you prefer
        private static string[] someDocuments = { "sys-design" };
        private static string[] someLanguages = { "hu" };

        private static bool update = true; // if true, only re-translate files that were edited (NOT WORKING)

        public static void Main(string[] args)
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            TranslateDocs translate = serviceProvider.GetService<TranslateDocs>();

            // ################  Translate documentation files ########################

            // UNCOMMENT one of the following lines as you prefer
            //TranslateDocumentsLanguages(allDocuments, allLanguages, update);
            //translate.TranslateDocuments(allDocuments, someLanguages, update);
            //translate.TranslateDocuments(someDocuments, allLanguages, update);
            //translate.TranslateDocuments(someDocuments, someLanguages, update);


            // ################  Add new language to lookup arrays for GUI ########################

            // UNCOMMENT this to add a new language to the arrays.
            //translate.AddNewLanguageToArrays("hu", "Hungarian")
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TranslateInCloud>();
            services.AddTransient<TranslateDocs>();

        }
    }
}
