﻿using System;
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
        public string DatafilesPath {get; set; }
        public string TestfilesPath { get; set; }
        public bool IsDevelopment { get; set; }
        public int FixasrSegmentSize { get; set; }
        public int FixasrSegmentOverlap { get; set; }
        public int RecordingSizeForDevelopment { get; set; }
        public int MaxWorkFileBackups { get; set; }
        public bool MoveIncomingFileAfterProcessing { get; set; }
        public string GoogleApplicationCredentials { get; set; }
        public EmailSettings Email { get; set; }
        public AdminUserSettings AdminUser { get; set; }
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
    public class AdminUserSettings
    {
        public string Username  { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
