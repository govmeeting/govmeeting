using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.ViewModels;
using GM.Configuration;
using GM.DatabaseModel;
using GM.Utilities;
using GM.DatabaseAccess;

namespace GM.FileDataRepositories
{
    // This is a "repository" of "viewable" transcripts. Viewable transcripts are the JSON files generated after  
    //  the tags are added.

    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string SUB_WORK_FOLDER = "ViewMeeting";
        const string WORK_FILE_NAME = "ToView.json";

        private readonly AppSettings _config;
        readonly IDBOperations dBOperations;

        public ViewMeetingRepository(
            IOptions<AppSettings> config,
            IDBOperations _dBOperations
            )
        {
            _config = config.Value;
            dBOperations = _dBOperations;
        }

        public ViewtranscriptView Get(long meetingId)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            ViewtranscriptView viewMeeting = JsonConvert.DeserializeObject<ViewtranscriptView>(latestFixes);
            return viewMeeting;
        }

        public bool Put(long meetingId, ViewtranscriptView value)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            bool result = cb.WriteLatest(stringValue);

            return result;
        }

        private string GetWorkFolderPath(long meetingId)
        {
            Meeting meeting = dBOperations.GetMeeting(meetingId);

            string workfolderName = dBOperations.GetWorkFolderName(meeting);

            string workFolder = _config.DatafilesPath  + workfolderName + @"\" + SUB_WORK_FOLDER;
            return workFolder;
        }

    }
}
