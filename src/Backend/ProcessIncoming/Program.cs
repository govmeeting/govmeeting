using System;
using System.IO;
namespace GM.ProcessIncoming
{

    // This console program processes transcripts in PDF format as they are produced by the government entity itself.
    // It produces a JSON file of the transcript, usable by the next step in the transcript editing process .
    // The next step is the insertion of topic (and section tags, if missing) by a volunteer using the "addtags" feature.
    class Program
    {
        // When in "TEST_MODE", we will immediately process any files currently in Datafiles\INCOMING and then exit.
        // When not in TEST_MODE, we will continually monitor the Datafiles\INCOMING folder for new files. When one
        // arrives, we will process it.
        static bool TEST_MODE = true;
        static void Main(string[] args)
        {
            ProcessFiles pf = new ProcessFiles();
            if (!TEST_MODE)
            {
                pf.WatchIncoming();
                string s = Console.ReadLine();
            }
            else
            {
                pf.RunTest();
            }
        }
    }
}
