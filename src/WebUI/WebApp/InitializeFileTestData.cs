using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GM.FileDataRepositories;
using GM.Utilities;

namespace GM.WebApp
{
    public static class InitializeFileTestData
    {
        // Copy sample test data from the "testdata" folder to the "DATAFILES" folder.
        public static void CopyTestData(string testfilesPath, string datafilesPath)
        {
            string[] dirs = new string[]
            {
                // This data is for a meeting that was transcribed from an .mp4 file and 
                //  the transcript is currently being proofread. When you run WebApp and click on "Fixasr",
                // this is the data that you will see.
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-02-15",     // For Fixasr
                //@"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-01-09",     // For Fixasr

                // This data is for a meeting for which was retrieved as a PDF file of the transcript.
                // The preprocessing was completed. We are now on the step of adding tags. When you run WebApp
                // and click on "Addtags", this is the data that you will see.
                @"USA_PA_Philadelphia_Philadelphia_CityCouncil_en\2014-09-25",       // For Addtags

                // This data is for a meeting that was transcribed, fixed and tags added. We can now view the completed
                // transcript. When you run WebApp and click on "ViewMeeting", this is the data that you will see.
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2014-09-08",     // For ViewMeeting
            };

            foreach (string dir in dirs)
            {
                string source = Path.Combine(testfilesPath, dir);
                string destination = Path.Combine(datafilesPath, "PROCESSING", dir);
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                    GMFileAccess.CopyContents(source, destination);
                }
            }
        }

    }
}
