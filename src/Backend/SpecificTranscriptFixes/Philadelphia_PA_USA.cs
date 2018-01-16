using System;
using System.IO;
using System.Text.RegularExpressions;
using GM.ProcessTranscriptLib;


namespace GM.SpecificTranscriptFixes
{
    public class Philadelphia_PA_USA : SpecificFixesBase
    {
        // original PDF sources at: http://legislation.phila.gov/council-transcriptroom/

        TranscriptFixes tf = new TranscriptFixes();

        public Philadelphia_PA_USA(string meetingDate, string logDirectory) : base(logDirectory)
        {
        }

        public string Fix(string _transcript)
        {
            transcript = _transcript;

            LOGPROGRESS("TXT of transcript");

            // Delete the date of the meeting that appears on each page
            //            DeleteDateLine(ref transcript);

            // Split the transcript into three sections: meeting info, list of officers and transcript text.
            Split(ref transcript, ref meetingInfo, ref officersNames);

            //string ss = "abc\n1 aaa\n22 ttt\nzzz\n";
            //tf.RemoveLinesExceptThoseStartingWithLineNumber(ref ss);
            tf.RemoveLinesExceptThoseStartingWithLineNumber(ref transcript);

            // Delete the line numbers
            DeleteLineNumbers(ref transcript);

            // Align text left
            AlignTextLeft(ref transcript);

            // Add "Speaker: <name-of-speaker>" before start of text by new speaker.
            FormatSpeakerHeaders(ref transcript);

            // Format the section headers as "Section: <name-of-section>"
            FormatSectionHeaders(ref transcript);

            // Delete blank lines and newlines that appear within paragaphs
            DeleteExtraNewlines(ref transcript);

            // Put newlines before & after section headers and before speaker headings.
            ReformatHeadings(ref transcript);


            return transcript;
        }

        // #############################################################################

        void DeleteLineNumbers(ref string transcript)
        {
            // Remove page and line numbers.
            tf.RemoveLineNumbers(ref transcript);

            LOGPROGRESS("DeleteLineNumbers");
        }

        void DeletePageAndLineNumbers(ref string transcript)
        {
            // Remove page and line numbers.
            tf.RemovePageAndLineNumbers(ref transcript);

            LOGPROGRESS("DeletePageAndLineNumbers");
        }

        void Split(ref string transcript, ref string meetingInfo, ref string officersNames)
        {
            // Get the meeting information
            meetingInfo = tf.LinesFromAndUpto(transcript, "    COUNCIL OF THE CITY OF PHILADELPHIA", "PRESENT:\n");
            tf.RemoveSpacesAtStartOfLine(ref meetingInfo);

            // Get the officers' names
            officersNames = tf.LinesBetween(transcript, "PRESENT:\n", "    - - -\n");
            tf.RemoveSpacesAtStartOfLine(ref officersNames);

            // Get the transcript of what was said
            transcript = tf.LinesBetween(transcript, "    - - -\n", "Page 1\nA\n");

            LOGPROGRESS("Split heading,speakers,text");
        }

        void FormatSectionHeaders(ref string transcript)
        {
            string pattern1 = "^.* - STATED - +(.*)$";
            string replacement = "    Section: $1\n";
            //Regex rgx = new Regex(pattern1);
            transcript = Regex.Replace(transcript, pattern1, replacement, RegexOptions.Multiline);

            // Sometimes a section header can occur within the text of someone speaking. Move to above current speaker.
            tf.MoveSectionHeaders(ref transcript);

            LOGPROGRESS("FormatSectionHeaders");
        }

        // The speaker names are all caps. But a name can have these characters within it: ' . -
        // For example: O'BRIAN, MR. SMITH and RUTH SMITH-JONES.
        void FormatSpeakerHeaders(ref string text)
        {
            // "-" is a meta-character when between two characters in a character class, but not when at the end.
            string pattern = "^    ([A-Z '.-]*): *";
            string replacement = "    Speaker: $1\n    ";
            text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);

            LOGPROGRESS("FormatSpeakerHeaders");
        }

        void DeleteExtraNewlines(ref string transcript)
        {
            tf.RemoveBlankLines(ref transcript);

            tf.RemoveNewlinesInsideParagraphs(ref transcript);

            LOGPROGRESS("DeleteExtraNewlines");
        }

        void AlignTextLeft(ref string transcript)
        {
            // Continuation lines for speaking can have up to 4 initial spaces.
            // We want them all to start flush left.
            tf.Remove4SpacesAtStartOfLine(ref transcript);

            // On the lines which still have 4 or more initial spaces, make them all four.
            tf.MakeAllIndents4Spaces(ref transcript);

            LOGPROGRESS("AlignTextLeft");
        }

        void ReformatHeadings(ref string transcript)
        {
            tf.ReFormatSectionHeaders(ref transcript);
            tf.ReFormatSpeakerHeaders(ref transcript);

            LOGPROGRESS("ReformatHeaders");
        }

    }
}
