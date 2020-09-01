using System.IO;
using GM.EditTranscript;
using GM.ProcessRecording;
using GM.Utilities;

namespace GM.Workflow
{
    public static class InitializeFileTestData {
        public static string CopyTestData(string testfilesPath, string datafilesPath, bool deleteProcessing)
        {
            if (!Directory.Exists(datafilesPath))
            {
                Directory.CreateDirectory(datafilesPath);
                Directory.CreateDirectory(datafilesPath + "/RECEIVED");
                Directory.CreateDirectory(datafilesPath + "/PROCESSING");
                Directory.CreateDirectory(datafilesPath + "/COMPLETED");
            } else {
                if (deleteProcessing)
                {
                    GMFileAccess.DeleteDirectoryContents(datafilesPath + @"\PROCESSING");
                }
            }

            if (!Directory.Exists(testfilesPath)){
                Directory.CreateDirectory(testfilesPath);
                return "TESTDATA folder missing";
            }

            // These are the test files that we will copy.
            string[] files = new string[]
            {
                // This meeting exists in MeetingRepository_Stub.cs
               //  as meeting #4 and status = "Received"
               "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf",

               // This meeting exists in MeetingRepository_Stub.cs
               //  as meeting #5 and status = "Received"
               "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",

                // This meeting is not present in MeetingRepository_Stub.cs.
                // ProcessIncomingFiles in WorkflowApp should recognize that fact,
                // and create a new meeting record for this file.
                "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4"
            };

            if (files.Length == 0)
            {
                return "TESTDATA folder empty";
            }

            foreach (string file in files)
            {
                string source = testfilesPath + "\\" + file;

                if (File.Exists(source)) {
                    string destination = datafilesPath + "\\" + "RECEIVED" + "\\" + file;
                    if (!File.Exists(destination))
                    {
                        // For testing, use only the first 9 minutes of the video recordings.
                        if (file.EndsWith(".mp4"))
                        {
                            //SplitRecording splitRecording = new SplitRecording();
                            AudioProcessing audioProcessing = new AudioProcessing();
                            audioProcessing.ExtractPart(source, destination, 0, 540);  // 9 * 60 sec.
                        } else
                        {
                            File.Copy(source, destination);
                        }
                    }
                }
            }
        return null;
        }
    }
}
