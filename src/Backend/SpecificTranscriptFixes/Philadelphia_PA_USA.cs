using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GM.ProcessTranscriptLib;


namespace GM.SpecificTranscriptFixes
{
    public class Philadelphia_PA_USA
    {
        string basefilename;
        string officersNames = "";
        string meetingInfo = "";
        string transcript = "";

        public string Fix(string _transcript, string _basefilename)
        {
            transcript = _transcript;
            basefilename = _basefilename;

            TranscriptFixes tf = new TranscriptFixes();

            // original sources at: 	http://legislation.phila.gov/council-transcriptroom/

            LOGPROGRESS("step1");

            // Delete these strings. Each page had what appears to be the name of the company providing transcription.
            string[] ToDelete = {
                    "Strehlow & Associates, Inc.",
                    "STREHLOW & ASSOCIATES, INC.",
                    "Stated Meeting Invocation",
                    "(215) 504-4622" };
            tf.DeleteStrings(ref transcript, ToDelete);

            // Remove page and line numbers.
            tf.RemovePageAndLineNumbers(ref transcript);

            LOGPROGRESS("step2");

            // Split the transcript into three sections: the meeting info, list of officers and the transcript text.

            // Get the meeting information
            meetingInfo = tf.LinesFromAndUpto(transcript, "    COUNCIL OF THE CITY OF PHILADELPHIA", "PRESENT:\n");
            tf.RemoveSpacesAtStartOfLine(ref meetingInfo);

            // Get the officers' names
            officersNames = tf.LinesBetween(transcript, "PRESENT:\n", "    - - -\n");
            tf.RemoveSpacesAtStartOfLine(ref officersNames);

            // Get the transcript of what was said
            transcript = tf.LinesBetween(transcript, "    - - -\n", "    - - -\n");

            LOGPROGRESS("step3");

            // Continuation lines for speaking can have up to 4 initial spaces. 
            // We want them all to start flush left.
            tf.Remove4SpacesAtStartOfLine(ref transcript);

            // On the lines which still have 4 or more initial spaces, make them all four.
            tf.MakeAllIndents4Spaces(ref transcript);

            // This adds "Section: <name-of-section>" before start of sections.
            tf.FormatSectionHeaders(ref transcript);

            // This adds "Speaker: <name-of-speaker>" before start of text by new speaker.
            tf.FormatSpeakerHeaders(ref transcript);

            LOGPROGRESS("step4");

            // Sometimes a section header can occur within the text of someone speaking. Move to above current speaker.
            tf.MoveSectionHeaders(ref transcript);

            tf.RemoveBlankLines(ref transcript);

            tf.RemoveNewlinesInsideParagraphs(ref transcript);

            tf.ReFormatSectionHeaders(ref transcript);
            tf.ReFormatSpeakerHeaders(ref transcript);

            LOGPROGRESS("step5");

            return transcript;
        }

        void LOGPROGRESS(string step)
        {
            File.WriteAllText(basefilename + "_" + step + ".txt", meetingInfo + "-----------------------------\n" + officersNames + "-----------------------------\n" + transcript);
        }
    }
}
