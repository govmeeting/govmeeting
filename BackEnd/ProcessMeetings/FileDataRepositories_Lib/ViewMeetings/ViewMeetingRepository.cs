using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
//using GM.DatabaseRepositories;
using GM.ViewModels;
using GM.Configuration;

namespace GM.FileDataRepositories
{
    // This is a "repository" of "viewable" transcripts. Viewable transcripts are the JSON files generated after  
    //  the tags are added.

    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string WORK_FOLDER_NAME = "ViewMeeting";
        const string WORK_FILE_NAME = "ToView.json";

        private readonly AppSettings _config;
        private readonly MeetingFolder _meetingFolder;

        public ViewMeetingRepository(
            IOptions<AppSettings> config,
            MeetingFolder meetingFolder
            )
        {
            _config = config.Value;
            _meetingFolder = meetingFolder;
        }

        public ViewmeetingView Get(long meetingId)
        {
            // TODO - Remove later - For development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(meetingFolder, _config.DatafilesPath, _config.TestfilesPath);

            string workFolderPath = GetWorkFolderPath(meetingId);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            ViewmeetingView viewMeeting = JsonConvert.DeserializeObject<ViewmeetingView>(latestFixes);
            return viewMeeting;
        }

        public bool Put(long meetingId, ViewmeetingView value)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            bool result = cb.WriteLatest(stringValue);

            return result;
        }

        private ViewmeetingView GetViewMeetingByPath(string meetingPath)
        {
            string meetingString = GMFileAccess.Readfile(meetingPath);
            if (meetingString != null)
            {
                ViewmeetingView meeting = JsonConvert.DeserializeObject<ViewmeetingView>(meetingString);
                return meeting;
            } else
            {
                return null;
            }
        }
        private string GetWorkFolderPath(long meetingId)
        {
            // We need to get the work path that is used for this meeting.
            // GetPathFromId will first get the information about the meeting from the database.
            // Then it will build the path name of the work folder.
            string meetingFolder = _meetingFolder.GetNameFromId(meetingId);
            string workFolder = meetingFolder + "\\" + WORK_FOLDER_NAME;
            string workFolderPath = Path.Combine(_config.DatafilesPath, workFolder);
            return workFolderPath;
        }

    }
}
