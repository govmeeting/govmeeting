using System;
using System.IO;
using GM.ProcessTranscriptLib;
using GM.SpecificTranscriptFixes;

namespace GM.ProcessTranscripts
{
    class Program
    {
        // We will need to research the various formats that each community uses
        // for its transcripts. We will initially create conversion routines for 
        // specific transcript formats. As we gain more knowledge of the required changes,
        // we can start generalizing these routines.

        static void Main(string[] args)
        {
            string[] transcipts = new string[] {
                "Philadelphia_CityCouncil_09-25-2014",
                "Philadelphia_CityCouncil_03_17_2016"
            };

            string testDataFolder = Environment.CurrentDirectory + "\\testdata";

            foreach (string filename in transcipts)
            {
                TranscriptFixes tf = new TranscriptFixes();
                Philadelphia_PA_USA philly = new Philadelphia_PA_USA();

                // Convert the PDF file to text
                string basefilename = testDataFolder + "\\" + filename;
                string pdfFile = basefilename + ".pdf";
                string text = tf.ConvertPdfToText(pdfFile);

                // Make the specific fixs to the philly data
                string transcript = philly.Fix(text, basefilename);

                // Convert to JSON
                tf.ConvertToJson(ref transcript);

                // Save as JSON file
                File.WriteAllText(basefilename + ".json", transcript);
            }
            // Austin_TX_USA();
        }
    }
}
