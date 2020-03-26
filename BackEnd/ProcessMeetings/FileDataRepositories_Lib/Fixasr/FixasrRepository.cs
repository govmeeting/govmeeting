using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.ViewModels;
//using GM.DatabaseRepositories;

namespace GM.FileDataRepositories
{
    public class FixasrRepository : IFixasrRepository
    {
        // We use a "circular buffer" to store the work files. The base name of the WORK_FILE will
        // be appended with a sequence number each time a new revision is stored.
        // The GetLatest and WriteLatest methods on on this buffer will return or store the latest revision.

        const string WORK_FOLDER_NAME = "Fixasr";
        const string WORK_FILE_NAME = "ToFix.json";

        private readonly AppSettings config;
        private readonly MeetingFolder meetingFolder;
        private readonly string datafiles;

        public FixasrRepository(
            IOptions<AppSettings> _config,
            MeetingFolder _meetingFolder
            )
        {
            config = _config.Value;
            meetingFolder = _meetingFolder;
            datafiles = config.DatafilesPath;
        }

        public FixasrView Get(long meetingId, int part)
        {
            string partFolder = GetPartFolder(meetingId, part);

            CircularBuffer cb = new CircularBuffer(partFolder, WORK_FILE_NAME, config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(latestFixes);
            return fixasr;
        }

        public bool Put(FixasrView value, long meetingId, int part)
        {
            string partFolder = GetPartFolder(meetingId, part);
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(partFolder, WORK_FILE_NAME, config.MaxWorkFileBackups);
            bool success = cb.WriteLatest(stringValue);

            return success;
        }

        private string GetPartFolder(long meetingId, int part)
        {
            string meetingFolderPath = meetingFolder.GetNameFromId(meetingId);

            string workFolder = meetingFolderPath + "\\" + WORK_FOLDER_NAME;
            string partFolder = workFolder + $"\\part{part:D2}";
            string partFolderPath = Path.Combine(datafiles, partFolder);

            return partFolderPath;
        }


    }
}
