using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Govmeeting.Volunteer.PreProcessTranscript
{
    // TODO: All methods in TranscriptFixes are in need of unit tests.

    public static class TranscriptFixes
    {
        /*
         * Convert a PDF file to a text file by extracting just the text.
        */
        public static void ConvertPdfToText(string infile, string outfile)
        {
            StringBuilder strPdfContent = new StringBuilder();

            PdfReader reader = new PdfReader(infile);

            /*
             * This conversion code is thanks to the developers of iTextSharp and asturcon at
             * http://www.codeproject.com/Questions/770857/Convert-PDF-tp-text-formatted-using-iTextSharp-csh 
             * Before this was used, manual conversion was done with Adobe Acrobat or Microsoft Word.
             * They both convert very badly - missing spaces, linefeeds, reversed lines, etc. Their problems appear
             * to be related to how they handle default character encoding on Windows. For an explanation, see:
             * https://www.informit.com/guides/content.aspx?g=dotnet&seqNum=163
             */
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                ITextExtractionStrategy objExtractStrategy = new SimpleTextExtractionStrategy();
                string strLineText = PdfTextExtractor.GetTextFromPage(reader, i, objExtractStrategy);
                strLineText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(strLineText)));

                strPdfContent.Append(strLineText);
                strPdfContent.Append("\n");
            }
            reader.Close();
            string text = strPdfContent.ToString();
            File.WriteAllText(outfile, text);
        }

        public static string LinesBetween(string text, string before, string after)
        {
            int i = text.IndexOf(before);
            int start = i + before.Length;
            int end = text.IndexOf(after, start);
            int len = end - start;
            return text.Substring(start, len);
        }

        public static string LinesFromAndUpto(string text, string from, string upto)
        {
            int start = text.IndexOf(from);
            int end = text.IndexOf(upto);
            int len = end - start;
            return text.Substring(start, len);
        }

        public static void DeleteStrings(ref string text, string[] ToDelete)
        {
            StringBuilder textBuilder = new StringBuilder(text);
            foreach (string s in ToDelete)
            {
                textBuilder.Replace(s, "");
            }
            text = textBuilder.ToString();
        }

        public static void MakeAllIndents4Spaces(ref string text)
        {
            string pattern = "^ +";
            string replacement = "    ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);

        }

        // Remove page numbers and line numbers.
        // This includes 1 or 2 digits plus space at start of lines and
        // "Page xx" at start of line.
        public static void RemovePageAndLineNumbers(ref string text)
        {
            string pattern1 = "^[0-9][0-9]?[ ]?";
            string pattern2 = "^Page [0-9][0-9]?$";
            string pattern = pattern1 + "|" + pattern2;
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
            //text = Regex.Replace(text, pattern2, replacement, RegexOptions.Multiline);
        }

        public static void RemoveSpacesAtStartOfLine(ref string text)
        {
            string pattern = "^[ ]+";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void Remove4SpacesAtStartOfLine(ref string text)
        {
            string pattern = "^ ? ? ? ?";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void RemoveBlankLines(ref string text)
        {
            string pattern = "^\n";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void RemoveNewlinesInsideParagraphs(ref string text)
        {
            string pattern = "\n([^ ])";
            string replacement = " $1";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void FormatSectionHeaders(ref string text)
        {
            string pattern1 = "^.* - STATED - +(.*)$";
            string replacement = "    Section: $1\n";
            //Regex rgx = new Regex(pattern1);
            text = Regex.Replace(text, pattern1, replacement, RegexOptions.Multiline);
        }

        // The speaker names are all caps. But a name can have these characters within it: ' . -
        // For example: O'BRIAN, MR. SMITH and RUTH SMITH-JONES.
        public static void FormatSpeakerHeaders(ref string text)
        {
            // "-" is a meta-character when between two characters in a character class, but not when at the end.
            string pattern = "^    ([A-Z '.-]*): *";
            string replacement = "    Speaker: $1\n    ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        // Section headers often occur within the text of someone speaking. This is because
        // the section headers were originally on the top of each page. We want to move these
        // headers to just before the text of the next speaker.
        public static void MoveSectionHeaders(ref string text)
        {
            StringWriter strWriter = new StringWriter();
            strWriter.NewLine = "\n";
            StringReader strReader = new StringReader(text);
            string nextLine;
            string sectionLine = null;
            Boolean wroteSection = false;
            string sectionLabel = "    Section:";
            int sectionLabelLen = sectionLabel.Length;
            string speakerLabel = "    Speaker:";
            int speakerLabelLen = speakerLabel.Length;
            while ((nextLine = strReader.ReadLine()) != null)
            {
                // check if this line is a section label and value.
                if ((nextLine.Length >= sectionLabelLen) && (nextLine.Substring(0, sectionLabelLen) == sectionLabel))
                {
                    // Put section names in all caps
                    nextLine = sectionLabel + nextLine.Substring(sectionLabelLen).ToUpper();

                    // If different section than last, use it.
                    if (nextLine != sectionLine)
                    {
                        sectionLine = nextLine;
                        wroteSection = false;
                    }
                }
                // check if this line is a speaker label and value.
                else if ((nextLine.Length >= speakerLabelLen) && (nextLine.Substring(0, speakerLabelLen) == speakerLabel))
                {
                    nextLine = speakerLabel + nextLine.Substring(speakerLabelLen);

                    if ((sectionLine != null) && (wroteSection == false))
                    {
                        strWriter.WriteLine(sectionLine);
                        wroteSection = true;
                    }
                    strWriter.WriteLine(nextLine);
                } else
                    strWriter.WriteLine(nextLine);
                }
            text = strWriter.ToString();
        }

        public static void ReFormatSectionHeaders(ref string text)
        {
            string pattern = "^    Section: +";
            string replacement = "\nSection: ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void ReFormatSpeakerHeaders(ref string text)
        {
            string pattern = "^    Speaker: +";
            string replacement = "\nSpeaker: ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void HighlightSectionHeaders(ref string text)
        {
            string pattern = "^Section: (.*)$";
            string replacement = "\n\n==============================\nSection: $1\n==============================\n";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public static void ConvertToJson(ref string text)
        {

            Talk talk = new Talk { speaker = null, said = null, section = null, topic = null, showSetTopic = false };

            StringWriter strWriter = new StringWriter();
            strWriter.NewLine = "\n";

            StringWriter said = new StringWriter();
            said.NewLine = "\n";

            StringReader strReader = new StringReader(text);
            string nextLine;
            bool firstRecord = true;

            string sectionLabel = "Section: ";
            int sectionLabelLen = sectionLabel.Length;
            string speakerLabel = "Speaker: ";
            int speakerLabelLen = speakerLabel.Length;

            strWriter.WriteLine("{ \"data\": [");

            while ((nextLine = strReader.ReadLine()) != null)
            {
                // if line is blank, ignore it.
                if (nextLine == "")
                {
                }
                // If line is section name, store it.
                else if ((nextLine.Length >= sectionLabelLen) && (nextLine.Substring(0, sectionLabelLen) == sectionLabel))
                {
                    if (talk.speaker != null)
                    {
                        strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
                    }
                    // ignore blank lines after Section: line.
                    talk.section = nextLine.Substring(sectionLabelLen);
                }
                // if line is speaker name, store it.
                else if ((nextLine.Length >= speakerLabelLen) && (nextLine.Substring(0, speakerLabelLen) == speakerLabel))
                {
                    if (talk.speaker != null)
                    {
                        strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
                    }
                    talk.speaker = nextLine.Substring(speakerLabelLen);

                }
                // If it is something else and we have a current speaker, it is what was said.
                else if (talk.speaker != null)
                {
                    said.WriteLine(nextLine);
                }
            }
            if (talk.speaker != null)
            {
                strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
            }
            strWriter.WriteLine("\n] }");
            text = strWriter.ToString();
        }

        static string JsonRecord(ref Talk talk, ref StringWriter said, ref bool firstRecord)
        {
            talk.said = said.ToString();

            string text = (firstRecord ? "" : ",") + "\n    " + new JavaScriptSerializer().Serialize(talk);
            firstRecord = false;

            talk.speaker = null;
            talk.section = null;
            talk.said = null;
            talk.topic = null;
            talk.showSetTopic = false;
            said.Dispose();
            said = new StringWriter();
            said.NewLine = "\n";
            return text;
        }
        
        /*
         * For debugging transcript formats - outputs the file in hex.
         */

        static void DisplayFileInHex(string filename)
        {
            using (TextReader reader = File.OpenText(filename))
            {
                while (reader.Peek() > -1)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                    char[] chars = line.ToCharArray();
                    foreach (char c in chars)
                    {
                        int value = Convert.ToInt32(c);
                        string hex = String.Format("{0:X}", value);
                        Console.Write("{0} ", hex);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
