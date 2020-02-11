﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GM.FileDataRepositories;

namespace WebApp.Data
{
    public static class InitializeFileTestData
    {
        // Copy sample test data from the "testdata" folder to the "Datafiles" folder.
        public static void CopyTestData(string testfilesPath, string datafilesPath)
        {
            string[] dirs = new string[]
            {
                // This data is for a meeting that we transcribed from an .mp4 file and we are currently
                // on the step of fixing the transcription. When you run WebApp and click on "Fixasr",
                // this is the data that you will see.
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-02-15",     // For Fixasr
                //@"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-01-09",     // For Fixasr

                // This data is for a meeting for which we retrieved a PDF of the transcript and already
                // did the preprocessing. We are now on the step of adding tags. When you run WebApp
                // and click on "Addtags", this is the data that you will see.
                @"USA_PA_Philadelphia_Philadelphia_CityCouncil_en\2014-09-25",       // For Addtags

                // This data is for a meeting that was transcribed, fixed and tags added. We can now view the completed
                // transcript. When you run WebApp and click on "ViewMeeting", this is the data that you will see.
                @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2014-09-08",     // For ViewMeeting
            };

            foreach (string dir in dirs)
            {
                string source = testfilesPath + "\\" + dir;
                string destination = datafilesPath + "\\" + dir;
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                    GMFileAccess.CopyContents(source, destination);
                }
            }
        }

    }
}
