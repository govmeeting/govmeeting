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
        // Default values are the production defaults
        public string ConnectionString { get; set; }
        public string DatabaseType { get; set; } = "UseConnectionString"; // others: InMemory, SQLite 
        public string DatafilesPath { get; set; }
        public string TestdataPath { get; set; }
        public bool DeleteProcessingFolderOnStartup { get; set; } = false;
        public int EditMeetingSegmentSize { get; set; } = 300; // seconds
        public int EditMeetingSegmentOverlap { get; set; } = 5; // seconds
        public int MaxRecordingSize { get; set; } = 0; // no limit
        public bool UseAudioFileAlreadyInCloud { get; set; } = false;
        public string GoogleCloudBucketName { get; set; } = "govmeeting-transcribe";
        public int MaxWorkFileBackups { get; set; } = 20;
        public bool ExitAfterOnceThroughWorkflow { get; set; } = false;
        public string GoogleApplicationCredentials { get; set; }
        public bool RequireManagerApproval { get; set; } = true;
        public bool InitializeWithTestData { get; set; } = false;
        public bool UseDatabaseStubs { get; set; } = false;
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
