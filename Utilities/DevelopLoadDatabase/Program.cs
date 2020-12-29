using System;
using System.IO;
////using GM.LoadDatabase;
using GM.Utilities;

namespace GM.Utilities.DevelopLoadDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            ////LoadDatabase loadDatabase = new LoadDatabase();
            string projectFolder = GMFileAccess.FindParentFolderWithName("DevelopLoadDatabase");
            string sampleDataFile = Path.Combine(projectFolder, "SampleTranscriptViewModel.json");

            ////loadDatabase.LoadSampleData(sampleDataFile);
        }
    }
}
