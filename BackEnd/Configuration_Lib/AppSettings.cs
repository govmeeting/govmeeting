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
        public string DatafilesPath {get; set; }
        public string TestfilesPath { get; set; }
        public bool IsDevelopment { get; set; }
        public int FixasrSegmentSize { get; set; }
        public int FixasrSegmentOverlap { get; set; }
        public int RecordingSizeForDevelopment { get; set; }
        public int MaxWorkFileBackups { get; set; }
        public bool MoveIncomingFileAfterProcessing { get; set; }
        public string GoogleApplicationCredentials { get; set; }
    }
}
