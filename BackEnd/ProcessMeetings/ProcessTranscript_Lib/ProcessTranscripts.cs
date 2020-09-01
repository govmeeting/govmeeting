using GM.FileDataRepositories;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace GM.ProcessTranscript
{

    public interface ITranscriptProcess
    {
        public string Process(string filename, string meetingFolder, string language);
    }

    public class TranscriptProcess : ITranscriptProcess
    {
        /*     ProcessTranscript process new transcript files that arrive.
         *     It performs the following steps:
         *       1. If PDF file, convert to plain text.
         *       2. Make location specific fixes to convert it to a standard format.
         *          For example: fixes for Philadelphia, PA, USA
         *       3. Convert the file to JSON format.
         */

        const string SUB_WORK_FOLDER = "ProcessTranscript";
        string subworkFolder;
        string location;

        public string Process(string sourcefilename, string meetingFolder, string language)
        {
            // TODO - FIX THIS KLUDGE
            // We extract the "location" name from the meetingFolder name.
            // These are the name used for location specific fixes. 
            // Get meeting folder name, EG: "USA_PA_Philadelphia_Philadelphia_CityCouncil_en__2017-12-07"
            string meetingFoldername = Path.GetDirectoryName(meetingFolder);
            // Remove end date to get "location", EG: "USA_PA_Philadelphia_Philadelphia_CityCouncil_en"
            int i = meetingFoldername.LastIndexOf("_");
            location = meetingFoldername.Substring(0, i - 1);

            subworkFolder = meetingFolder + "\\" + SUB_WORK_FOLDER + "\\";
            Directory.CreateDirectory(subworkFolder);  
            if (sourcefilename.ToLower().EndsWith(".pdf"))
            {
                return ProcessPdf(sourcefilename, language);
            }
            string workfile = subworkFolder + "2 plain-text.txt";
            File.Copy(sourcefilename, workfile);
            string text = File.ReadAllText(workfile);
            return TextFixes(text);
        }

        private string ProcessPdf(string filename, string language)
        {

            // Step 1 - Copy PDF to meeting workfolder

            string outfile = subworkFolder + "1 original.pdf";
            File.Copy(filename, outfile);

            // Step 2 - Convert the PDF file to text

            string text = ConvertPdfToText.Convert(outfile);
            outfile = subworkFolder + "2 plain-text.txt";
            File.WriteAllText(outfile, text);

            return TextFixes(text);
        }

        private string TextFixes(string text)
        {
            // Step 3 - Fix the transcript text: Put in common format

            TranscriptFixes transcriptFixes = new TranscriptFixes();
            string transcript = transcriptFixes.Fix(subworkFolder, text, location);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            //string outfile = workFolder + "3 ToBeTagged.json";
            //File.WriteAllText(outfile, transcript);

            return transcript;
        }

        //private void CreateWorkFolder(string meetingFolder)
        //{
        //    workFolder = meetingFolder + "\\" + SUB_WORK_FOLDER + "\\";
        //    Directory.CreateDirectory(workFolder);
        //}

    }
}
