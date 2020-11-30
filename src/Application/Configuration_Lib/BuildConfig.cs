using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using GM.Utilities;
using System.IO;

namespace GM.Configuration
{
    public static class BuildConfig
    {
        public static void Build(IConfigurationBuilder config, string environment)
        {
            // App settings that are set later override earlier ones.
            // appsettings.secrets.json contain secrets stored outside of our Github repo.
            // appsettings.Production.json is also stored in the SECRETS folder.
            // For Development, shared settings in "solution_items" are linked into WebApp & WorkflowApp.
            // https://andrewlock.net/including-linked-files-from-outside-the-project-directory-in-asp-net-core/>

            if (environment == "Development")
            {
                string solutionFolder = GMFileAccess.GetSolutionFolder();
                string secretsFolder = GMFileAccess.GetSecretsFolder();

                config
                .AddJsonFile(Path.Combine(solutionFolder, "appsettings.Shared.json"), optional: true)
                .AddJsonFile(Path.Combine(secretsFolder, "appsettings.Secrets.json"), optional: true)
                .AddJsonFile(Path.Combine(solutionFolder, $"appsettings.{environment}.json"), optional: true);
            }
            else
            {
                config
                .AddJsonFile("appsettings.Secrets.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true);
            }
            config.AddEnvironmentVariables();
        }
    }
}
