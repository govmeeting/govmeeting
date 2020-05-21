using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GM.Configuration
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string LogfilesPath { get; set; }
        public string DatafilesPath { get; set; }
        public string TestdataPath { get; set; }
        public bool DeleteProcessingFolderOnStartup { get; set; }
        public bool IsDevelopment { get; set; }
        public int FixasrSegmentSize { get; set; }
        public int FixasrSegmentOverlap { get; set; }
        public int RecordingSizeForDevelopment { get; set; }
        public bool UseAudioFileAlreadyInCloud { get; set; }
        public string GoogleCloudBucketName { get; set; }
        public int MaxWorkFileBackups { get; set; }
        public bool ExitAfterOnceThroughWorkflow { get; set; }
        public string GoogleApplicationCredentials { get; set; }
        public bool RequireManagerApproval { get; set; }
        public bool InitializeWithTestData { get; set; }
        public bool UseDatabaseStubs { get; set; }
        public DbAdminSettings DbAdmin { get; set; }
    }

    public class EmailSettings
    {
        public string From { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Security { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class DbAdminSettings
    {
        public string Username  { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
