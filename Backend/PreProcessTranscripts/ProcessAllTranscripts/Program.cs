using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Govmeeting.Volunteer.PreProcessTranscript;


namespace Govmeeting.Volunteer.PreProcessTranscripts
{
    class Program
    {
        static string TestDataFolder = @"..\..\..\testdata\";

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
            foreach (string s in transcipts)
            {
                Philadelphia_PA_USA(s);
            }
            // Austin_TX_USA();
        }

        static void Philadelphia_PA_USA(string filename)
        {
            // original sources at: 	http://legislation.phila.gov/council-transcriptroom/

            string pdfFile = TestDataFolder + filename + ".pdf";

            // Save changes at various points so we can see the progress. 

            TranscriptFixes.ConvertPdfToText(pdfFile, filename + "_Step1.txt");

            string text = File.ReadAllText(filename + "_Step1.txt");

            // Delete these strings
            string[] ToDelete = {
                "Strehlow & Associates, Inc.",
                "STREHLOW & ASSOCIATES, INC.",
                "Stated Meeting Invocation",
                "(215) 504-4622" };
            TranscriptFixes.DeleteStrings(ref text, ToDelete);

            // Remove page numbers and line numbers.
            TranscriptFixes.RemovePageAndLineNumbers(ref text);

            // Save progress to step2.
            File.WriteAllText(filename + "_Step2.txt", text);

            // Get the meeting information
            string MeetingInfo = TranscriptFixes.LinesFromAndUpto(text, "    COUNCIL OF THE CITY OF PHILADELPHIA", "PRESENT:\n");
            TranscriptFixes.RemoveSpacesAtStartOfLine(ref MeetingInfo);

            // Get the officers' names
            string OfficersNames = TranscriptFixes.LinesBetween(text, "PRESENT:\n", "    - - -\n");
            TranscriptFixes.RemoveSpacesAtStartOfLine(ref OfficersNames);

            // Get the transcript of what was said
            string transcript = TranscriptFixes.LinesBetween(text, "    - - -\n", "    - - -\n");

            string step3 = MeetingInfo + "-----------------------------\n" + OfficersNames + "-----------------------------\n" + transcript;
            File.WriteAllText(filename + "_Step3.txt", step3);

            //string text1 = "    ABCDF.JUHGT'OOOP:  hiya all.\n good to see ya.\n";
            //TranscriptFixes.FormatSpeakerHeaders(ref text1);

            // Continuation lines for speaking can have up to 4 initial spaces. 
            // We want them all to start flush left.
            TranscriptFixes.Remove4SpacesAtStartOfLine(ref transcript);

            // On the lines which still have 4 or more initial spaces, make them all four.
            TranscriptFixes.MakeAllIndents4Spaces(ref text);

            TranscriptFixes.FormatSectionHeaders(ref transcript);

            TranscriptFixes.FormatSpeakerHeaders(ref transcript);

            string step4 = MeetingInfo + "-----------------------------\n" + OfficersNames + "-----------------------------\n" + transcript;
            File.WriteAllText(filename + "_Step4.txt", step4);

            TranscriptFixes.MoveSectionHeaders(ref transcript);

            TranscriptFixes.RemoveBlankLines(ref transcript);

            TranscriptFixes.RemoveNewlinesInsideParagraphs(ref transcript);

            TranscriptFixes.ReFormatSectionHeaders(ref transcript);
            TranscriptFixes.ReFormatSpeakerHeaders(ref transcript);

            File.WriteAllText(filename + "_Step5.txt", transcript);

            TranscriptFixes.ConvertToJson(ref transcript);

            File.WriteAllText(filename + ".json", transcript);

            TranscriptFixes.HighlightSectionHeaders(ref transcript);

            string step5 = MeetingInfo + "-----------------------------\n" + OfficersNames + "-----------------------------\n" + transcript;
            File.WriteAllText(filename + "_Step6.txt", step5);

        }

        static void Austin_TX_USA()
        {
            string pdfFile = TestDataFolder + @"Austin_TX_CityCouncil_08-07-2014.pdf";

            TranscriptFixes.ConvertPdfToText(pdfFile, "Austin_Step1");

            string text = File.ReadAllText("Austin_Step1");
        }
    }
}
