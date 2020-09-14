using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// The methods in this file are only to be used during Development.

namespace GM.Utilities
{
    public static partial class GMFileAccess
    {
        public static string GetTestdataFolder()
        {
            return FindParentFolderWithName("TESTDATA");
        }

        public static string GetClientAppFolder()
        {
            return Path.Combine(GetGovmeetingSolutionFolder(), "frontend", "clientapp");
        }

        public static string GetWebAppFolder()
        {
            return Path.Combine(GetGovmeetingSolutionFolder(), "BackEnd", "WebApp");
        }

        public static string GetWorkflowAppFolder()
        {
            return Path.Combine(GetGovmeetingSolutionFolder(), "BackEnd", "WorkflowApp");
        }

        public static string GetGovmeetingSolutionFolder()
        {
            return FindParentFolderContaining("govmeeting.sln");
        }

        /* GetProjectSiblingFolder is for creating/finding sibling folders to the project.
        * These include: _TESTDATA, DATAFILES, SECRETS.
        * These folders must be outside the project folder so that they are not 
        * included in the code repository.
        * The names are coming from appsettings.json. The name could be just
        * the folder name in development. But in production, it will be a rooted path.
        * In production, we just return the path.
        */
        public static string GetProjectSiblingFolder(string name)
        {
            if (Path.IsPathRooted(name))
            {
                return name;
            }
            string projectFolder = FindParentFolderContaining("govmeeting.sln");
            string path = Path.Combine(projectFolder, "../" + name);
            path = Path.GetFullPath(path);
            return path;
        }

        public static void SetGoogleCredentialsEnvironmentVariable()
        {
            // Find path to the SECRETS folder
            string credentialsFilePath;
            string secrets = FindParentFolderWithName("SECRETS");
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
