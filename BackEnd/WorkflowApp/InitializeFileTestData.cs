using System.IO;
using GM.ProcessRecording;

namespace GM.Workflow
{
    public static class InitializeFileTestData {
        public static void CopyTestData(string testfilesPath, string datafilesPath)
        {
            Directory.CreateDirectory(datafilesPath + "\\" + "RECEIVED");

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
                string destination = datafilesPath + "\\" + "RECEIVED" + "\\" + file;
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
