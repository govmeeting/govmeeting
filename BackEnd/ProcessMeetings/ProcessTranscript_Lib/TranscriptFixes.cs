using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GM.ProcessTranscript
{
    // TODO All methods in TranscriptFixes are in need of unit tests.

    // NOTE: During the text fixes, a trace files is written to the work folder after each step.
    // Each trace file contains the complete text of the transcript, after each particular fix is applied.
    // Therefore if the final fixed transcript contains strange or invalid text, it is easy to trace it
    // back to where those errors were introduced during the "fix" process.

    public class TranscriptFixes
    {
        public string Fix( string meetingDate, string logDirectory, string text)
        {
            string transcript;
            if (true)
            {
                //// Make the specific fixes to the philly data
                Specific_Philadelphia_PA_USA philly = new Specific_Philadelphia_PA_USA(logDirectory);
                transcript = philly.Fix(text);

            }
            return transcript;
        }
    }
}
