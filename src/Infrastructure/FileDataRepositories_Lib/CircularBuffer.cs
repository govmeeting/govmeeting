using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using GM.WebApp.Models;
using GM.Utilities;

namespace GM.FileDataRepositories
{
    // This class implements a circular buffer of files, where each new set of fixes is saved to a new file.
    // After max files is reached, the latest one will overwrite the oldest one.

    // Whenever the user clicks "SAVE" after making corrections, we save the corrected text to a new file.
    // Assume that original file containing the uncorrected text is named "ToFix.json"
    // When the user clicks "SAVE" for the first time, the changed text is saved to "ToFix-corrected-01-LAST.json".
    //    "01" indicates that this is the first set of corrections.
    //    "LAST" indicates this is most recent set of corrections.
    // When the user makes more corrections and clicks "SAVE" again, two things happen:
    //   The new second set of corrections are saved to "ToFix-corrected-02-LAST.json".
    //   "ToFix-corrected-01-LAST.json" is renamed "ToFix-corrected-01.json"
    // If the user logs out and logs in again later to continue working, they get the file whose name ends with "LAST.json".

    // After "MAX_BACKUPS" files are created (currently 20), the latest file written will wipe out the older file.
    // Thus instead of the 21th file being named ""ToFix-corrected-21-LAST.json", it is named "ToFix-corrected-01-LAST.json".
    // Thus this arrangement acts like a circular buffer, where the newest entry wipes out the oldest one.

    // We can provide the user an "Undo" function which will go back to a prior set of corrections.

    // It is possible to use a more sophisticated approach, like using mediawiki software to track revisions. But
    // this current approach only takes about 50 lines of code and it may be sufficient for our purposes.

    public class CircularBuffer
    {
        readonly int maxBackups;
        readonly string meetingSegmentFolder;
        readonly string basename;
        readonly string baseNameCorrected;
        readonly string extension;

        public CircularBuffer(string _meetingSegmentFolder, string workfile, int _maxBackups)
        {
            meetingSegmentFolder = _meetingSegmentFolder;
            basename = Path.GetFileNameWithoutExtension(workfile);
            extension = Path.GetExtension(workfile);
            baseNameCorrected = basename + "-v";    // Base name of the file which has corrections.
            maxBackups = _maxBackups;
        }
        public string GetLatest()
        {
            string latestCopy = Path.Combine(meetingSegmentFolder, baseNameCorrected + extension);

            // If we already edited it, return the latest edit.
            if (File.Exists(latestCopy))
            {
                return GetByPath(latestCopy);
            }
            // Otherwise return the unedited one.
            else
            {
                string filename = Path.Combine(meetingSegmentFolder, basename + extension);
                return GetByPath(filename);
            }
        }

        //public bool SaveLatest(string stringValue)
        //{
        //    return true;
        //}

        string GetByPath(string path)
        {
            try
            {
                string fixasrString = GMFileAccess.Readfile(path);
                if (fixasrString != null)
                {
                    return fixasrString;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool WriteLatest(string stringValue)
        {
            // const string STEP3_BASE_NAME = "x";   // for testing
            const string SUFFIX = "-LAST";
            const string SEPERATOR = " - ";


            string numOfNextLatest = "01";          // Assume the next latest is "01".

            try
            {
                // Find out what the current latest is.
                string latestCopy = GetLatestFile(meetingSegmentFolder, baseNameCorrected, extension);
                if (latestCopy != null)
                {
                    numOfNextLatest = GetNumberOfNextLatest(latestCopy, SUFFIX, extension);
                    RenameLatestCopy(latestCopy, SUFFIX);
                }

                string nextLatestCopy = meetingSegmentFolder + "/" + baseNameCorrected + SEPERATOR + numOfNextLatest + SUFFIX + "." + extension;
                File.WriteAllText(nextLatestCopy, stringValue);
            }
            catch
            {
                return false;
            }

            return true;
        }

        // get filename of latest copy
        private string GetLatestFile(string fullpath, string basename, string extension)
        {
            const string SUFFIX = "-LAST";

            string[] files = Directory.GetFiles(fullpath, basename + "*" + SUFFIX + "." + extension);
            if (files.Length == 1)
            {
                return files[0];
            }
            return null;
        }

        private void RenameLatestCopy(string latestCopy, string suffix)
        {
            string newname = latestCopy.Replace(suffix, "");
            File.Move(latestCopy, newname);
        }

        // get number of next latest copy (as string)
        private string GetNumberOfNextLatest(string latestCopy, string suffix, string extension)
        {
            int startOfnumLast = latestCopy.Length - suffix.Length - extension.Length - 3;

            string numpart = latestCopy.Substring(startOfnumLast, 2);
            bool res = int.TryParse(numpart, out int numLast);
            if (!res)
            {
                // TODO - handle error
                return "01";
            }
            if (++numLast > maxBackups)
            {
                numLast = 1;
            }
            // http://timtrott.co.uk/string-formatting-examples/
            return String.Format("{0:d2}", numLast);
        }
    }
}
