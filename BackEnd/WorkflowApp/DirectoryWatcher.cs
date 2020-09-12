using System;
using System.IO;

namespace GM.WorkflowApp
{
    public class DirectoryWatcher {

        public delegate void DoWorkOnFile(string filename);

        DoWorkOnFile doWork;
        public void watch(string path, string filter, DoWorkOnFile _doWork)
        {
            doWork = _doWork;

            FileSystemWatcher watcher = new FileSystemWatcher()
            {
                Path = path,
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = filter,
            };

            // Start monitoring events
            watcher.Changed += new FileSystemEventHandler(OnChanged);

            // Toddo - OnChanged only gets fired if the file is COPIED to the folder and
            // not if it is MOVED to the folder. I tried these two event handlers
            // but neither get called either when the file is moved.
            //watcher.Created += new FileSystemEventHandler(OnCreated);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }

        // FileSystemWatcher has a number of problems that are discussed often in SO and elsewhere.
        // The two main ones, which we are concerned with are:
        //  1. There can be many events fired when a single new file appears in a directory.
        //  2. When the OnChanged event is fired, the last write on the file may not have completed so the 
        //     file is not yet ready.
        // When we receive the OnChanged event, we will try to open the file to see if it is ready.
        // If not, we will wait and keep trying for a few seconds.
        // The DirectoryWatcher is for a background batch process, so we are not concerned with immediately
        // responding to the new file.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!IsFileReady(e.FullPath)) return; //first notification the file is arriving

            //The file has completed arrived, so lets process it
            doWork(e.FullPath);
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            if (!IsFileReady(e.FullPath)) return; //first notification the file is arriving

            //The file has completed arrived, so lets process it
            doWork(e.FullPath);
        }

        private void OnRenamed(object source, FileSystemEventArgs e)
        {
            if (!IsFileReady(e.FullPath)) return; //first notification the file is arriving

            //The file has completed arrived, so lets process it
            doWork(e.FullPath);
        }


        private bool IsFileReady(string path)
        {
            //One exception per file rather than several like in the polling pattern
            int retryCount = 20;
            int timeBetweenRetries = 200; // in milliseconds
            int x = 0;
            while (x++ <= retryCount) {
                try
                {
                    //If we can't open the file, it's still copying
                    using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Console.WriteLine($"We had {x} retries.");
                        return true;
                    }
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(timeBetweenRetries);
                }
            }
            // Retry count is exhausted. We failed.
            return false;
        }
    }
}