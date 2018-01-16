using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.ProcessTranscriptLib;
using GM.SpecificTranscriptFixes;
using GM.Utilities;

namespace GM.ProcessIncoming
{
    class ProcessTranscripts
    {
        string datafiles = Environment.CurrentDirectory + @"\..\..\Datafiles";
        bool TEST = false;

        public ProcessTranscripts(bool _test)
        {
            TEST = _test;
        }

        public void Process(string filename)
        {
            string meetingFolder;

            CreateMeetingFolder(filename, out meetingFolder);

            // Copy PDF to meeting directory
            FileInfo infile = new FileInfo(filename);
            string outfile = meetingFolder + "\\" + "Step 1 - PDF of transcript.pdf";
            File.Copy(filename, outfile);

            // Convert the PDF file to text
            string text = ConvertPdfToText.Convert(outfile);

            // Make the specific fixes to the philly data
            Philadelphia_PA_USA philly = new Philadelphia_PA_USA("2016-03-17", meetingFolder);
            string transcript = philly.Fix(text);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            string jsonfile = meetingFolder + "\\" + "Step 3 - JSON output.json";
            File.WriteAllText(jsonfile, transcript);

            if (!TEST)
            {
                // Move the original PDF to "COMPLETED" folder
                File.Move(filename, datafiles + "\\" + "COMPLETED");
            }

        }

        private bool CreateMeetingFolder (string filename, out string meetingFolder)
        {
            // If file is "USA_PA_Philadelphia_Philadelphia_CityCouncil 2016-03-17.pdf"
            //     location = USA_PA_Philadelphia_Philadelphia_CityCouncil
            //     meetingDate = 2016-03-17
            //     meetingFolder = USA_PA_Philadelphia_Philadelphia_CityCouncil/2016-03-17
            string name = Path.GetFileNameWithoutExtension(filename);
            string location = name.Substring(0, name.Length - 11);
            string meetingDate = name.Substring(name.Length - 10, 10);
            meetingFolder = datafiles + "\\" + location + "\\" + meetingDate;

            if (!TEST)
            {
                if (Directory.Exists(meetingFolder))
                {
                    return false;
                }
                else
                {
                    Directory.CreateDirectory(meetingFolder);
                    return true;
                }
            }

            // If this is test, delete contents if it exists. Otherwise create folder.
            if (!Directory.Exists(meetingFolder))
            {
                Directory.CreateDirectory(meetingFolder);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(meetingFolder);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            return true;
        }
    }
}
