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
        // We use a "circular buffer" to store the work files. The base name of the WORK_FILE will
        // be appended with a sequence number each time a new revision is stored.
        // The GetLatest and WriteLatest methods on on this buffer will return or store the latest revision.

        const string WORK_FOLDER_NAME = "Addtags";
        const string WORK_FILE_NAME = "ToTag.json";

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
            // TODO - Remove later - For development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(workFolder, _config.DatafilesPath, _config.TestfilesPath);

            string workFolderPath = GetWorkFolderPath(meetingId);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            AddtagsView addtags = JsonConvert.DeserializeObject<AddtagsView>(latestFixes);
            return addtags;
        }

        //public void Put(string value)
        public bool Put(AddtagsView value, long meetingId)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            bool result = cb.WriteLatest(stringValue);

            return result;
        }

        public string GetWorkFolderPath(long meetingId)
        {
            string meetingFolder = _meetingFolder.GetNameFromId(meetingId);
            string workFolder = meetingFolder + "\\" + WORK_FOLDER_NAME;
            string workFolderPath = Path.Combine(_config.DatafilesPath, workFolder);
            return workFolderPath;
        }
    }
}
