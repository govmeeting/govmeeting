using GM.Utilities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GM.Application.Configuration
{
    public static class BuildConfig
    {
        public static void Build(IConfigurationBuilder config, string environment)
        {
            // The SECRETS" folder is outside of our Github repo. In this folder is:
            //    appsettings.Secrets.json - secrets used in both production and development.
            //    appsettings.Production.json - production-only settings
            // appsettings.Development.json and appsettings.Staging.jaon are stored in solution root.
            // They are read by both WebApp & WorkflowApp.
            // Appsettings that are set later override earlier ones.
            // https://andrewlock.net/including-linked-files-from-outside-the-project-directory-in-asp-net-core/

            if (environment == "Production")
            {
                // For production, the appsettings files are in the deployment folder.
                config
                .AddJsonFile("appsettings.Secrets.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true);
            }
            else
            {
                // For development & staging, get the appsettings files from the SECRETS and solution folders.
                string solutionFolder = GMFileAccess.GetSolutionFolder();
                string secretsFolder = GMFileAccess.GetSecretsFolder();

                config
                    .AddJsonFile(Path.Combine(solutionFolder, "appsettings.Development.json"), optional: true)
                    .AddJsonFile(Path.Combine(secretsFolder, "appsettings.Secrets.json"), optional: true);

                if (environment == "Staging")
                {
                    // The Staging build run WebApp, clientapp and the database in separate docker containers.
                    config.AddJsonFile(Path.Combine(solutionFolder, "appsettings.Staging.json"), optional: true);
                }
            }

            // Allow appsettings to be overidden by an optional "appsettings.json" file in the project or deployment folder.
            // Currently, neither WebApp nor WorkflowApp have one.
            config.AddJsonFile("appsettings.json", optional: true);

            // Environment settings override all else.
            config.AddEnvironmentVariables();
        }
    }
}
