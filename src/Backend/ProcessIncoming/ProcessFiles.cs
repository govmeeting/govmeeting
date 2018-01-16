using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.ProcessRecordingLib;
using GM.Utilities;

namespace GM.ProcessIncoming
{
    class ProcessFiles
    {
        // Todo - This should come from appsettings.json when this code is called from WebApp
        string datafiles = Environment.CurrentDirectory + @"\..\..\Datafiles";

        // Watch the "Datafiles\INCOMING" folder for the arrival of new files
        // and process them as they arrive.
        public void WatchIncoming()
        {
            string incoming = datafiles + @"\INCOMING";
                if (!Directory.Exists(incoming))
                {
                    Directory.CreateDirectory(incoming);
                }

                DirectoryWatcher watcher = new DirectoryWatcher();

            // "doWork" will get called when a new file is written to Datafiles\INCOMING.
            watcher.watch(incoming, "", doWork);
        }

        public void doWork(string filename)
        {
            FileInfo file = new FileInfo(filename);
            string extension = file.Extension;
            switch (extension)
            {
                case "pdf":
                    ProcessTranscript(filename, false);
                    break;
                case "mp4":
                    ProcessTranscript(filename, false);
                    break;
            }
        }

        private void ProcessTranscript(string filename, bool test)
        {
            ProcessTranscripts pt = new ProcessTranscripts(test);
            pt.Process(filename);

        }

        private void ProcessVideo(string filename, bool test)
        {
            ProcessTranscripts pt = new ProcessTranscripts(test);
            pt.Process(filename);
            ProcessRecording processRec = new ProcessRecording();
            processRec.Process(filename, datafiles);
        }

        // ################################################################################################

        // For Testing: Immediately process any files that are in "Datafiles\INCOMING".
        public void RunTest()
        {
            string incoming = datafiles + @"\INCOMING";

            string[] transcripts = Directory.GetFiles(incoming, "*.pdf");
            foreach (string transcript in transcripts)
            {
                ProcessTranscript(transcript, true);
            }
            string[] videos = Directory.GetFiles(incoming, "*.mp4");
            foreach (string video in videos)
            {
                ProcessVideo(video, true);
            }
        }


    }
}
