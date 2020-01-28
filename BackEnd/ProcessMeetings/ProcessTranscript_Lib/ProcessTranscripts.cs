using System;
using System.IO;

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

        public bool ProcessTxt(string filename, string meetingFolder, string language)
        {
            CreateWorkFolder(meetingFolder);
            string workfile = workFolder + "2 plain-text.txt";
            File.Copy(filename, workfile);
            string text = File.ReadAllText(workfile);
            return TextFixes(text);
        }
        public bool ProcessPdf(string filename, string meetingFolder, string language)
        {

            // Step 1 - Copy PDF to meeting directory

            FileInfo infile = new FileInfo(filename);
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
            // Step 3 - Fix the transcript: Put in common format

            //// Make the specific fixes to the philly data
            //Specific_Philadelphia_PA_USA philly = new Specific_Philadelphia_PA_USA("2016-03-17", workFolder);
            //string transcript = philly.Fix(text);

            TranscriptFixes transcriptFixes = new TranscriptFixes();
            string transcript = transcriptFixes.Fix("2016-03-17", workFolder, text);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            string outfile = workFolder + "3 ToBeTagged.json";
            File.WriteAllText(outfile, transcript);

            return true;
        }

        private void CreateWorkFolder(string meetingFolder)
        {
            //bool created;
            //MeetingInfo mi = new MeetingInfo(filename);
            //string meetingFolder = mi.MeetingFolder(datafiles);
            //if (!(created = FileSystem.CreateDirectory(meetingFolder)))
            //{
            //    Console.WriteLine("ProcessTranscripts.cs - ERROR: Could not create meeting folder. It may already exist.");
            //    return false;
            //}

            workFolder = meetingFolder + "\\" + WORK_FOLDER + "\\";
            Directory.CreateDirectory(workFolder);
        }

    }
}
