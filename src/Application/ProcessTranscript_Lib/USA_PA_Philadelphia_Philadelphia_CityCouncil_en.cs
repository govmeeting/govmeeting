using NLog.Fluent;
using ProcessTranscript_Lib;
using System;
using System.IO;
using System.Text.RegularExpressions;


namespace GM.Application.ProcessTranscript
{
    public class USA_PA_Philadelphia_Philadelphia_CityCouncil_en : ISpecificFix
    {
        // original PDF sources at: http://legislation.phila.gov/council-transcriptroom/

        private string meetingInfo = "";
        private string officersNames = "";
        private string transcriptText;      // spoken text

        CommonFixes cf = new CommonFixes();
        LogProgress lp = new LogProgress();

        public string Fix(string _transcript, string workfolder)
        {
            /* First we split the transcript into three parts: meeting header, list of officers' name and the text of meeting.
             * Currently we don't use the information in the meeting header or the list of officers' names.
             * That's because we already have the meeting information encoded into the file name -- and
             * the AddTags code later gets its list of speakers at the meeting from the transcript text itself.
             * THerefore, we only return the transcipt text from this method and discard the meeting header and officer names.
             * This will likely change in the future. We should at least save the names for officer attendence records.
             */

            // Extract the meeting header
            meetingInfo = cf.LinesFromAndUpto(_transcript, "    COUNCIL OF THE CITY OF PHILADELPHIA", "PRESENT:\n");
            cf.RemoveSpacesAtStartOfLine(ref meetingInfo);

            // Extract the officers' names
            officersNames = cf.LinesBetween(_transcript, "PRESENT:\n", "    - - -\n");
            cf.RemoveSpacesAtStartOfLine(ref officersNames);

            // Extract the text of what was said
            transcriptText = cf.LinesBetween(_transcript, "    - - -\n", "Page 1\nA\n");

            // LogProgress will store the meeting header and officer names sections,
            // so that it can write those to the trace files for each step of the conversion.
            // On calls to lp.Log, we will only pass the new transcriptText.

            lp.Initialize(meetingInfo, officersNames, workfolder);
            lp.Log("Split heading,speakers,text", transcriptText);

            // Return the meeting text.
            return FixTextOfTranscript();
        }

        private string FixTextOfTranscript()
        {
            //string ss = "abc\n1 aaa\n22 ttt\nzzz\n";
            //cf.RemoveLinesExceptThoseStartingWithLineNumber(ref ss);
            cf.RemoveLinesExceptThoseStartingWithLineNumber(ref transcriptText);

            // Delete the line numbers
            DeleteLineNumbers(ref transcriptText);

            // Align text left
            AlignTextLeft(ref transcriptText);

            // Add "Speaker: <name-of-speaker>" before start of text by new speaker.
            FormatSpeakerHeaders(ref transcriptText);

            // Format the section headers as "Section: <name-of-section>"
            FormatSectionHeaders(ref transcriptText);

            // Delete blank lines and newlines that appear within paragaphs
            DeleteExtraNewlines(ref transcriptText);

            // Put newlines before & after section headers and before speaker headings.
            ReformatHeadings(ref transcriptText);

            return transcriptText;
        }

        // #############################################################################

        void DeleteLineNumbers(ref string transcript)
        {
            // Remove page and line numbers.
            cf.RemoveLineNumbers(ref transcript);

            lp.Log("DeleteLineNumbers", transcriptText);
        }


        void FormatSectionHeaders(ref string transcriptText)
        {
            string pattern1 = "^.* - STATED - +(.*)$";
            string replacement = "    Section: $1\n";
            //Regex rgx = new Regex(pattern1);
            transcriptText = Regex.Replace(transcriptText, pattern1, replacement, RegexOptions.Multiline);

            // Sometimes a section header can occur within the text of someone speaking. Move to above current speaker.
            cf.MoveSectionHeaders(ref transcriptText);

            lp.Log("FormatSectionHeaders", this.transcriptText);
        }

        // The speaker names are all caps. But a name can have these characters within it: ' . -
        // For example: O'BRIAN, MR. SMITH and RUTH SMITH-JONES.
        void FormatSpeakerHeaders(ref string text)
        {
            // "-" is a meta-character when between two characters in a character class, but not when at the end.
            string pattern = "^    ([A-Z '.-]*): *";
            string replacement = "    Speaker: $1\n    ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);

            lp.Log("FormatSpeakerHeaders", this.transcriptText);
        }

        void DeleteExtraNewlines(ref string transcript)
        {
            cf.RemoveBlankLines(ref transcript);

            cf.RemoveNewlinesInsideParagraphs(ref transcript);

            lp.Log("DeleteExtraNewlines", this.transcriptText);
        }

        void AlignTextLeft(ref string transcript)
        {
            // Continuation lines for speaking can have up to 4 initial spaces.
            // We want them all to start flush left.
            cf.Remove4SpacesAtStartOfLine(ref transcript);

            // On the lines which still have 4 or more initial spaces, make them all four.
            cf.MakeAllIndents4Spaces(ref transcript);

            lp.Log("AlignTextLeft", this.transcriptText);
        }

        void ReformatHeadings(ref string transcript)
        {
            cf.ReFormatSectionHeaders(ref transcript);
            cf.ReFormatSpeakerHeaders(ref transcript);

            lp.Log("ReformatHeaders", this.transcriptText);
        }

    }
}
