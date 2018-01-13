using  System;
using System.IO;

namespace GM.Utilities {
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
        watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!IsFileReady(e.FullPath)) return; //first notification the file is arriving

            //The file has completed arrived, so lets process it
            doWork(e.FullPath);
        }
        private bool IsFileReady(string path)
        {
            //One exception per file rather than several like in the polling pattern
            try
            {
                //If we can't open the file, it's still copying
                using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}