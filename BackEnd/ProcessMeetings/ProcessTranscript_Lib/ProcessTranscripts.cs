using GM.FileDataRepositories;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace GM.ProcessTranscript
{
    public class TranscriptProcess
    {
        /*     ProcessTranscript process new transcript files that arrive.
         *     It performs the following steps:
         *       1. If PDF file, convert to plain text.
         *       2. Make location specific fixes to convert it to a standard format.
         *          For example: fixes for Philadelphia, PA, USA
         *       3. Convert the file to JSON format.
         */

        const string WORK_FOLDER = "PreProcess";
        string workFolder;
        string location;

        public bool Process(string filename, string meetingFolder, string language)
        {
            //MeetingFolder mf = new MeetingFolder(filename);
            ////mf.SetFields(filename);
            //location = mf.location;

            // TODO - FIX THIS KLUDGE
            // Get the location as a string from the filename.
            // Skip the starting meetingId and the ending date and extension.
            int i = filename.IndexOf("_");
            int j = filename.LastIndexOf("_");
            location = filename.Substring(i + 1, j - 1);

            workFolder = meetingFolder + "\\" + WORK_FOLDER + "\\";
            Directory.CreateDirectory(workFolder);  
            if (filename.ToLower().EndsWith(".pdf"))
            {
                return ProcessPdf(filename, language);
            }
            string workfile = workFolder + "2 plain-text.txt";
            File.Copy(filename, workfile);
            string text = File.ReadAllText(workfile);
            return TextFixes(text);
        }

        private bool ProcessPdf(string filename, string language)
        {

            // Step 1 - Copy PDF to meeting workfolder

            string outfile = workFolder + "1 original.pdf";
            File.Copy(filename, outfile);

            // Step 2 - Convert the PDF file to text

            string text = ConvertPdfToText.Convert(outfile);
            outfile = workFolder + "2 plain-text.txt";
            File.WriteAllText(outfile, text);

            return TextFixes(text);
        }

        private bool TextFixes(string text)
        {
            // Step 3 - Fix the transcript text: Put in common format

            TranscriptFixes transcriptFixes = new TranscriptFixes();
            string transcript = transcriptFixes.Fix(workFolder, text, location);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            string outfile = workFolder + "3 ToBeTagged.json";
            File.WriteAllText(outfile, transcript);

            return true;
        }

        //private void CreateWorkFolder(string meetingFolder)
        //{
        //    workFolder = meetingFolder + "\\" + WORK_FOLDER + "\\";
        //    Directory.CreateDirectory(workFolder);
        //}

    }
}
