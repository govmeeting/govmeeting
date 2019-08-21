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
    //  the tags are addeds.

    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string WORK_FOLDER = "ViewMeeting";
        private const string BASE_NAME = "1 tagged";
        private const string EXTENSION = "json";

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
            // We need to get the work path that will be used for this meeting.
            // GetPathFromId will first get the information about the meeting from the database.
            // Then it will build the path name of the work folder.
            string meetingFolder = _meetingFolder.GetPathFromId(meetingId);

            // Todo-g - Remove later - For development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(meetingFolder, _config.DatafilesPath, _config.TestfilesPath);


            string latestCopy = Path.Combine(_config.DatafilesPath, meetingFolder, WORK_FOLDER + "\\" + BASE_NAME + "." + EXTENSION);

            if (File.Exists(latestCopy))
            {
                return GetViewMeetingByPath(latestCopy);
            }
            else
            {
                return null;
            }
        }

        private ViewmeetingView GetViewMeetingByPath(string path)
        {
            string meetingString = GMFileAccess.Readfile(path);
            if (meetingString != null)
            {
                ViewmeetingView meeting = JsonConvert.DeserializeObject<ViewmeetingView>(meetingString);
                return meeting;
            } else
            {
                return null;
            }
        }
    }
}
