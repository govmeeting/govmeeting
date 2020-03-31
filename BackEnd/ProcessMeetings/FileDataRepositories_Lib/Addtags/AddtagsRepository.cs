using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.ViewModels;
using GM.Configuration;
using GM.DatabaseModel;
using GM.DatabaseRepositories;

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
        private readonly MeetingFolder meetingFolder;
        IMeetingRepository meetingRepository;          // database meeting repository
        IGovBodyRepository govBodyRepository;          // database govbody repository


        public AddtagsRepository(
            IOptions<AppSettings> config,
            MeetingFolder _meetingFolder,
            IMeetingRepository _meetingRepository,
            IGovBodyRepository _govBodyRepository
           )
        {
            _config = config.Value;
            meetingFolder = _meetingFolder;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        public AddtagsView Get(long meetingId)
        {
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
            Meeting meeting = meetingRepository.Get(meetingId);
            GovernmentBody g = govBodyRepository.Get(meeting.GovernmentBodyId);
            string language = g.Languages[0].Name;

            meetingFolder.SetFields(g.Country, g.State, g.County, g.Municipality, meeting.Date, g.Name, language);

            //string meetingFolder = _meetingFolder.GetPath();
            string meetingFolderPath = meetingFolder.path;


            string workFolder = meetingFolderPath + "\\" + WORK_FOLDER_NAME;
            string workFolderPath = Path.Combine(_config.DatafilesPath, "PROCESSING", workFolder);
            return workFolderPath;
        }
    }
}
