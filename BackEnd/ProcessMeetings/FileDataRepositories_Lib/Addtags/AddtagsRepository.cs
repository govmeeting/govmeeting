using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.ViewModels;
using GM.Configuration;

namespace GM.FileDataRepositories
{
    public class AddtagsRepository : IAddtagsRepository
    {
        const string WORK_FOLDER = "Addtags";
        const string WORK_FILE = "ToTag.json";

        private readonly AppSettings _config;
        private readonly MeetingFolder _meetingFolder;

        public AddtagsRepository(
            IOptions<AppSettings> config,
            MeetingFolder meetingFolder
            )
        {
            _config = config.Value;
            _meetingFolder = meetingFolder;
        }

        public AddtagsView Get(long meetingId)
        {
            string meetingFolder = _meetingFolder.GetPathFromId(meetingId);
            string workFolder = meetingFolder + "\\" + WORK_FOLDER;

            // TODO - Remove later - For development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(workFolder, _config.DatafilesPath, _config.TestfilesPath);

            string toTagFolderPath = Path.Combine(_config.DatafilesPath, workFolder);

            CircularBuffer cb = new CircularBuffer(toTagFolderPath, WORK_FILE, _config.MaxWorkFileBackups);

            string latestFixes = cb.GetLatest();
            AddtagsView addtags = JsonConvert.DeserializeObject<AddtagsView>(latestFixes);
            return addtags;
        }

        //public void Put(string value)
        public bool Put(AddtagsView value, long meetingId)
        {
            string meetingFolder = _meetingFolder.GetPathFromId(meetingId);
            string workFolder = meetingFolder + "\\" + WORK_FOLDER;

            string meetingTotagFolder = Path.Combine(_config.DatafilesPath, workFolder);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(meetingTotagFolder, WORK_FILE, _config.MaxWorkFileBackups);
            bool success = cb.WriteLatest(stringValue);
            return success;
        }
    }
}
