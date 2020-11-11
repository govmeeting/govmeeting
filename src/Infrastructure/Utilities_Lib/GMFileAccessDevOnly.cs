using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// The methods in this file are only to be used during Development.

namespace GM.Utilities
{
    public static partial class GMFileAccess
    {
        /* GetSolutionSiblingFolder is for creating/finding sibling folders to the project.
        * These include: TESTDATA, DATAFILES, SECRETS.
        * These folders must be outside the project folder so that they are not 
        * included in the code repository.
        * The names come from appsettings.json. In Development, this name is a
        * sibling of the solution folder. But in production, it will be a rooted path.
        * In production, we just return the path.
        */
        public static string GetSolutionSiblingFolder(string folder)
        {
            if (Path.IsPathRooted(folder))
            {
                return folder;
            }
            string parentOfSolution = Directory.GetParent(GetSolutionFolder()).FullName;
            return Path.Combine(parentOfSolution, folder);
        }

        public static string GetTestdataFolder() =>
            GetSolutionSiblingFolder("TESTDATA");

        public static string GetSecretsFolder() =>
            GetSolutionSiblingFolder("SECRETS");

        public static string GetSolutionFolder() =>
            FindParentFolderContaining("govmeeting.sln");

        public static string GetWebAppFolder() =>
            Path.Combine(GetSolutionFolder(), "src", "WebUI", "WebApp");

        public static string GetClientAppFolder() =>
            Path.Combine(GetWebAppFolder(), "clientapp");

        public static string GetWorkflowAppFolder() =>
            Path.Combine(GetSolutionFolder(), "src", "Workflow", "WorkflowApp");

        public static void SetGoogleCredentialsEnvironmentVariable()
        {
            // Find path to the SECRETS folder
            string credentialsFilePath;
            string secrets = GetSecretsFolder();
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

        }


    }
}
