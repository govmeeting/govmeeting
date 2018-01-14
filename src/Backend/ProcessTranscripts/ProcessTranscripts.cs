using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.ProcessTranscriptLib;
using GM.SpecificTranscriptFixes;
using GM.Utilities;

namespace GM.ProcessTranscripts
{
    class ProcessTranscripts
    {
        string datafiles = Environment.CurrentDirectory + @"\..\..\Datafiles";
        bool TEST = false;

        public void Process()
        {
            string incoming = datafiles + @"\INCOMING";
            DirectoryWatcher watcher = new DirectoryWatcher();

            // Watch for new PDF files in the INCOMING folder.
            // "doWork" will get called when a new one is written.
            watcher.watch(incoming, "*.pdf", doWork);
        }

        public void RunTest()
        {
            TEST = true;
            string incoming = datafiles + @"\INCOMING";
            string[] files = Directory.GetFiles(incoming, "*.pdf");
            foreach (string file in files)
            {
                doWork(file);
            }
        }

        private void doWork(string filename)
        {
            // If file is "USA_PA_Philadelphia_Philadelphia_CityCouncil 2016-03-17.pdf"
            //     location = USA_PA_Philadelphia_Philadelphia_CityCouncil
            //     meetingDate = 2016-03-17.pdf
            string name = Path.GetFileNameWithoutExtension(filename);
            string location = name.Substring(0, name.Length - 11);
            string meetingDate = name.Substring(name.Length - 10, 10);
            string meetingFolder = datafiles + "\\" + location + "\\" + meetingDate;

            // Meeting folder, for example, will be: "USA_PA_Philadelphia_Philadelphia_CityCouncil/2016-03-17"
            if (Directory.Exists(meetingFolder))
            {
                if (TEST)
                {
                    Directory.Delete(meetingFolder, true);
                }
                else
                {
                    return;
                }
            }
            Directory.CreateDirectory(meetingFolder);

            // Copy PDF to meeting directory
            FileInfo infile = new FileInfo(filename);
            string outfile = meetingFolder + "\\" + "Step 1 - PDF of transcript.pdf";
            File.Copy(filename, outfile);

            // Convert the PDF file to text
            string text = ConvertPdfToText.Convert(outfile);

            // Make the specific fixes to the philly data
            Philadelphia_PA_USA philly = new Philadelphia_PA_USA(meetingDate, meetingFolder);
            string transcript = philly.Fix(text);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            string jsonfile = meetingFolder + "\\" + Path.GetFileNameWithoutExtension(filename) + ".json";
            File.WriteAllText(jsonfile, transcript);

            if (!TEST)
            {
                // Move the original PDF to "COMPLETED" folder
                File.Move(filename, datafiles + "\\" + "COMPLETED");
            }

        }

        private bool CreateMeetingFolder (string location, string meetingDate)
        {
            string directory = datafiles + "\\" + location + "\\" + meetingDate;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                return true;
            }
            return false;
        }
    }
}
