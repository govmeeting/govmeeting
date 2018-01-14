using System;
using System.IO;
using GM.ProcessTranscriptLib;
using GM.SpecificTranscriptFixes;
using GM.Utilities;

namespace GM.ProcessTranscripts
{

    // This console program processes transcripts in PDF format as they are produced by the government entity itself.
    // It produces a JSON file of the transcript, usable by the next step in the transcript editing process 
    // (insertion of topic tags).
    class Program
    {static 
        bool TEST = true;
        static void Main(string[] args)
        {
            ProcessTranscripts pt = new ProcessTranscripts();
            if (!TEST)
            {
                pt.Process();
                string s = Console.ReadLine();
            }
            else
            {
                pt.RunTest();
            }
        }

    }
}
