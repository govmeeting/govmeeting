using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GM.ProcessTranscript
{
    // TODO All methods in TranscriptFixes are in need of unit tests.

    public class TranscriptFixes
    {
        public string Fix(string text, string meetingDate, string logDirectory)
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
