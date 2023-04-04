using Microsoft.Extensions.DependencyInjection;

namespace GM.Utilities.TranslateText
{
    public class Program
    {
        private static readonly string[] allDocuments = { "overview1", "overview2", "workflow", "project-status", "setup", "sys-design", "dev-notes", "database" };
        private static readonly string[] allLanguages = { "de", "es", "fr", "it", "fi", "ar", "sw", "zh", "pt", "bn", "hi" };

        // Edit these arrays as you prefer
        private static readonly string[] someDocuments = { "sys-design" };
        private static readonly string[] someLanguages = { "hu" };

        private static readonly bool update = true; // if true, only re-translate files that were edited (NOT WORKING)

        public static void Main()
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            TranslateDocs translate = serviceProvider.GetService<TranslateDocs>();

            // ################  Translate documentation files ########################
            // Define what documents we want to translate: alldocuments or someDocuments.
            // Define what languages we want to translate to: allLanguages or someLanguages
            string[] DOCS = allDocuments;
            string[] LANGS = allLanguages;
            translate.TranslateDocuments(DOCS, LANGS, update);

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
