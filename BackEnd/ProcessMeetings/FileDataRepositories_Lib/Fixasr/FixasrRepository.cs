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
        const string WORK_FOLDER = "Fixasr";
        const string WORK_FILE = "ToFix.json";

        private readonly AppSettings _config;
        private readonly MeetingFolder _meetingFolder;

        public FixasrRepository(
            IOptions<AppSettings> config,
            MeetingFolder meetingFolder
            )
        {
            _config = config.Value;
            _meetingFolder = meetingFolder;
        }

        public FixasrView Get(long meetingId, int part)
        {
            string meetingFolder = _meetingFolder.GetPathFromId(meetingId);

            string workFolder = meetingFolder + "\\" + WORK_FOLDER;
            string partFolder = workFolder + $"\\part{part:D2}";


            // Todo-g - Remove later - for development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(workFolder, _config.DatafilesPath, _config.TestfilesPath);

            string partFolderPath = Path.Combine(_config.DatafilesPath, partFolder);

            CircularBuffer cb = new CircularBuffer(partFolderPath, WORK_FILE, _config.MaxWorkFileBackups);

            string latestFixes = cb.GetLatest();
            FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(latestFixes);
            return fixasr;
        }

        public bool Put(FixasrView value, long meetingId, int part)
        {
            string meetingFolder = _meetingFolder.GetPathFromId(meetingId);

            string meetingSegmentFolder = System.IO.Path.Combine(_config.DatafilesPath, meetingFolder);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(meetingSegmentFolder, WORK_FILE, _config.MaxWorkFileBackups);
            bool success = cb.WriteLatest(stringValue);
            return success;
        }
    }
}
