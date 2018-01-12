using System;
using System.IO;
using GM.ProcessTranscriptLib;
using GM.SpecificTranscriptFixes;

namespace GM.ProcessTranscripts
{

    // This console program processes transcripts in PDF format as they are produced by the government entity itself.
    // It produces a JSON file of the transcript, usable by the next step in the transcript editing process 
    // (insertion of topic tags).
    class Program
    {
        static void Main(string[] args)
        {
            string[] transcipts = new string[] {
                "2016-03-17 USA_PA_Philadelphia_Philadelphia_CityCouncil"
            };

            string incomingRecordings = Environment.CurrentDirectory + @"\..\..\Datafiles\IN_PROCESS";
            string testDataFolder = Environment.CurrentDirectory + "\\testdata";

            foreach (string filename in transcipts)
            {
                TranscriptFixes tf = new TranscriptFixes();
                Philadelphia_PA_USA philly = new Philadelphia_PA_USA();

                // Convert the PDF file to text
                string basefilename = incomingRecordings + "\\" + filename;
                string pdfFile = basefilename + ".pdf";
                string text = ConvertPdfToText.Convert(pdfFile);

                // Make the specific fixes to the philly data
                string transcript = philly.Fix(text, basefilename);

                // Convert the fixed transcript to JSON
                ConvertToJson.Convert(ref transcript);
                File.WriteAllText(basefilename + "_stepX.json", transcript);
            }
            // Austin_TX_USA();
        }
    }
}
