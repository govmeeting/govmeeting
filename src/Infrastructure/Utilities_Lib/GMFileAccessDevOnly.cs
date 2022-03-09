using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// The methods in this file are only to be used during Development.

namespace GM.Utilities
{
    public static partial class GMFileAccess
    {
        public static string GetSolutionSiblingFolder(string childPath)
        {
            string parentOfSolution = Directory.GetParent(GetSolutionFolder()).FullName;
            return Path.Combine(parentOfSolution, childPath);
        }

        public static string GetTestdataFolder() =>
            GetSolutionSiblingFolder("TESTDATA");

        public static string GetSecretsFolder() =>
            GetSolutionSiblingFolder("SECRETS");

        public static string GetSolutionFolder() =>
            FindParentFolderContaining("govmeeting.sln");

        private static string GetWebAppFolder() =>
            Path.Combine(GetSolutionFolder(), "src", "WebUI", "WebApp");

        public static string GetClientAppFolder() =>
            Path.Combine(GetWebAppFolder(), "clientapp");

        private static string GetWorkflowAppFolder() =>
            Path.Combine(GetSolutionFolder(), "src", "Workflow", "WorkflowApp");

        public static void SetGoogleCredentialsEnvironmentVariable()
        {
            // Find path to the SECRETS folder
            string credentialsFilePath;
            string secrets = GetSecretsFolder();
            // If it exists look there for Google Application Credentials.
            if (secrets != null)
            {
                // TODO These credentials are now used for both transcribing and translating text.
                // They may also be used for other purposes. We should rename the file and also
                // the GCP project "TranscribeAudio" to something more general.
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

            // Here is an alternate way of setting the credentials:
            //    https://cloud.google.com/sdk/gcloud/reference/auth/application-default/login

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);
        }
    }
}
