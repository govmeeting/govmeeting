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
            // The SECRETS" folder is outside of our Github repo. In this folder is:
            //    appsettings.Secrets.json - secrets used in both production and development.
            //    appsettings.Production.json - production-only settings
            // At the solution root is stored appsettings.Development.json. This file is read by
            // both WebApp & WorkflowApp.
            // Appsettings that are set later will override earlier ones.
            // https://andrewlock.net/including-linked-files-from-outside-the-project-directory-in-asp-net-core/

            if (environment == "Development")
            {
                // For development, get the appsettings files from the SECRETS and solution folders.
                string solutionFolder = GMFileAccess.GetSolutionFolder();
                string secretsFolder = GMFileAccess.GetSecretsFolder();

                config
                .AddJsonFile(Path.Combine(solutionFolder, "appsettings.Development.json"), optional: true)
                .AddJsonFile(Path.Combine(secretsFolder, "appsettings.Secrets.json"), optional: true);

            } else {
                // Otherwise, assume that the appsettings files are in the deployment folder.
                config
                .AddJsonFile("appsettings.Secrets.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true);
            }

            // Allow appsettings to be overidden by an optional "appsettings.json" file in the project folder.
            // Currently, neither WebApp nor WorkflowApp have one.
            config.AddJsonFile("appsettings.json", optional: true);

            // Environment settings override all else.
            config.AddEnvironmentVariables();
        }
    }
}
