using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
//using GM.DatabaseRepositories;
using GM.ViewModels;
using GM.Configuration;
using GM.DatabaseRepositories;
using GM.DatabaseModel;

namespace GM.FileDataRepositories
{
    // This is a "repository" of "viewable" transcripts. Viewable transcripts are the JSON files generated after  
    //  the tags are added.

    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string WORK_FOLDER_NAME = "ViewMeeting";
        const string WORK_FILE_NAME = "ToView.json";

        private readonly AppSettings _config;
        IMeetingRepository meetingRepository;          // database meeting repository
        IGovBodyRepository govBodyRepository;          // database govbody repository

        public ViewMeetingRepository(
            IOptions<AppSettings> config,
            IMeetingRepository _meetingRepository,
            IGovBodyRepository _govBodyRepository
            )
        {
            _config = config.Value;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        public ViewmeetingView Get(long meetingId)
        {
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
            Meeting meeting = meetingRepository.Get(meetingId);

            //// Create the work folder
            //MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            //string workFolderPath = _config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;


            GovernmentBody g = govBodyRepository.Get(meeting.GovernmentBodyId);

            string language = g.Languages[0].Name;

            MeetingFolder meetingFolder = new MeetingFolder(g.Country, g.State, g.County, g.Municipality, meeting.Date, g.Name, language);
            string meetingFolderPath = meetingFolder.path;


            string workFolder = meetingFolderPath + "\\PROCESSING\\" + WORK_FOLDER_NAME;
            string workFolderPath = Path.Combine(_config.DatafilesPath, workFolder);
            return workFolderPath;
        }

    }
}
