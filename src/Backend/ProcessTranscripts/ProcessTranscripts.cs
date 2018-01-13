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
        public void Process()
        {
            string incoming = datafiles + @"\INCOMING";
            DirectoryWatcher watcher = new DirectoryWatcher();

            // Watch for new PDF files in the INCOMING folder.
            // "doWork" will get called when a new one is written.
            watcher.watch(incoming, "*.pdf", doWork);
        }


        private void doWork(string filename)
        {
            string inprocess = datafiles + @"\IN_PROCESS";

            // Copy the new file from "INCOMING" to "INPROCESS" folder
            FileInfo infile = new FileInfo(filename);
            string outfile = inprocess + "\\" + infile.Name;
            File.Move(filename, outfile);

            // Convert the PDF file to text
            string text = ConvertPdfToText.Convert(outfile);

            // Make the specific fixes to the philly data
            string name = Path.GetFileNameWithoutExtension(outfile);
            string meetingDate = name.Substring(name.Length - 10, 10);
            Philadelphia_PA_USA philly = new Philadelphia_PA_USA(meetingDate, Path.GetDirectoryName(outfile));
            string transcript = philly.Fix(text);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            string jsonfile = inprocess + "\\" + Path.GetFileNameWithoutExtension(filename) + ".json";
            File.WriteAllText(jsonfile, transcript);

        }
    }
}
