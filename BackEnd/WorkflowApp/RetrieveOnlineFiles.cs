using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using System.IO;
using GM.ProcessRecording;

namespace GM.Workflow
{
    public class RetrieveOnlineFiles
    {
        // TODO - IMPLEMENT THIS CLASS
        // Instead of retrieving online files, we currently just copy some test files into
        // the INCOMING folder. The next step in the workflow, ProcessIncomingFiles, will
        // then see the new files and start to process them.

        /* RetrieveOnlineFiles will:
         * Read the meeting schedules for all government bodies in the database.
         * 1. If a current meeting may have taken place, it will:
         *    Check the website where either its transcript or a recording may be found.
         *    If found it will:
         * 2. Create a "meeting" record in the database for this meeting and set the WorkStatus field to "Retrieving".
         * 3. Start the file retrieval.
         * 4. Store the retieved file in the "Datafiles/INCOMING" folder.
         * 5. Set the Workstatus on the meeting record to "Retrieved".
         * Repeat for each government body.
         */

        AppSettings _config;

        public RetrieveOnlineFiles(
           IOptions<AppSettings> config
        )
        {
            _config = config.Value;
        }
       public void Run()
        {
            // For now, we will just move some test data from the "testdata" folder to simulate retrieving files.
            CopyTestData();
        }

        private void CopyTestData()
        {
            string testfilesPath = _config.TestfilesPath;
            string datafilesPath = _config.DatafilesPath;

            Directory.CreateDirectory(datafilesPath + "\\" + "INCOMING");
            Directory.CreateDirectory(datafilesPath + "\\" + "PROCESSED");

            // These are the test files that we will copy.
            string[] files = new string[]
            {
                "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf",
               // TODO - This is about 58MB. Github prefers < 50.
               //"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4"

               //"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4"

            };

            foreach (string file in files)
            {
                string destination = datafilesPath + "\\" + "INCOMING" + "\\" + file;
                if (!File.Exists(destination))
                {
                    string source = testfilesPath + "\\" + file;

                    // For testing, use only the first 9 minutes of the video recordings.
                    if (file.EndsWith(".mp4"))
                    {
                        SplitRecording splitRecording = new SplitRecording();
                        splitRecording.ExtractPart(source, destination, 0, 540);  // 9 * 60 sec.
                    } else
                    {
                        File.Copy(source, destination);
                    }
                }
            }
        }

    }
}
