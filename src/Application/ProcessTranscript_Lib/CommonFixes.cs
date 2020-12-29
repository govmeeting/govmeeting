using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GM.Application.ProcessTranscript
{
    class CommonFixes
    {

        public string LinesBetween(string text, string before, string after)
        {
            int i = text.IndexOf(before);
            int start = i + before.Length;
            int end = text.IndexOf(after, start);
            int len = end - start;
            return text.Substring(start, len);
        }

        public string LinesFromAndUpto(string text, string from, string upto)
        {
            int start = text.IndexOf(from);
            int end = text.IndexOf(upto);
            int len = end - start;
            return text.Substring(start, len);
        }

        // Delete multiple strings. For example:
        //   string[] ToDelete = {
        //      "Strehlow & Associates, Inc.",
        //      "Stated Meeting Invocation",
        //      "(215) 504-4622" };
        //   DeleteStrings(ref transcript, ToDelete);
        public void DeleteStrings(ref string text, string[] ToDelete)
        {
            StringBuilder textBuilder = new StringBuilder(text);
            foreach (string s in ToDelete)
            {
                textBuilder.Replace(s, "");
            }
            text = textBuilder.ToString();
        }

        public void MakeAllIndents4Spaces(ref string text)
        {
            string pattern = "^ +";
            string replacement = "    ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);

        }

        // Remove line numbers.
        // This includes 1 or 2 digits plus space at start of lines
        public void RemoveLineNumbers(ref string text)
        {
            string pattern = "^[0-9][0-9]?[ ]?";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
            //text = Regex.Replace(text, pattern2, replacement, RegexOptions.Multiline);
        }
        // Remove page numbers and line numbers.
        // This includes 1 or 2 digits plus space at start of lines and
        // "Page xx" at start of line.
        public void RemovePageAndLineNumbers(ref string text)
        {
            string pattern1 = "^[0-9][0-9]?[ ]?";
            string pattern2 = "^Page [0-9][0-9]?$";
            string pattern = pattern1 + "|" + pattern2;
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
            //text = Regex.Replace(text, pattern2, replacement, RegexOptions.Multiline);
        }

        public void RemoveSpacesAtStartOfLine(ref string text)
        {
            string pattern = "^[ ]+";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void Remove4SpacesAtStartOfLine(ref string text)
        {
            string pattern = "^ ? ? ? ?";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void RemoveBlankLines(ref string text)
        {
            string pattern = "^\n";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void RemoveNewlinesInsideParagraphs(ref string text)
        {
            string pattern = "\n([^ ])";
            string replacement = " $1";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }
        public void RemoveLineContainingOnlyThisText(ref string text, string remove)
        {
            string pattern = "^ *" + remove + " *\n";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void RemoveLinesExceptThoseStartingWithLineNumber(ref string text)
        {
            string pattern = "^[^1-9].*\n";
            string replacement = "";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        // Section headers often occur within the text of someone speaking. This is because
        // the section headers were originally on the top of each page. We want to move these
        // headers to just before the text of the next speaker.
        public void MoveSectionHeaders(ref string text)
        {
            StringWriter strWriter = new StringWriter
            {
                NewLine = "\n"
            };
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
                }
                else
                    strWriter.WriteLine(nextLine);
            }
            text = strWriter.ToString();
        }

        public void ReFormatSectionHeaders(ref string text)
        {
            string pattern = "^    Section: +";
            string replacement = "\nSection: ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void ReFormatSpeakerHeaders(ref string text)
        {
            string pattern = "^    Speaker: +";
            string replacement = "\nSpeaker: ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        public void HighlightSectionHeaders(ref string text)
        {
            string pattern = "^Section: (.*)$";
            string replacement = "\n\n==============================\nSection: $1\n==============================\n";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
        }

        /*
         * For debugging transcript formats - outputs the file in hex.
         */

        void DisplayFileInHex(string filename)
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
