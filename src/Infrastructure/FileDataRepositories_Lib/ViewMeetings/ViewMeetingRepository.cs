using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Application.Configuration;
////using GM.Infrastructure.InfraCore.Data;

namespace GM.Infrastructure.FileDataRepositories.ViewMeetings
{
    // This is a "repository" of "viewable" transcripts. Viewable transcripts are the
    // JSON files generated after the tags are added.

    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string SUB_WORK_FOLDER = "ViewMeeting";
        const string WORK_FILE_NAME = "ToView.json";

        private readonly AppSettings _config;

        public ViewMeetingRepository(
            IOptions<AppSettings> config
            )
        {
            _config = config.Value;
        }

        public string Get(long meetingId)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            return latestFixes;
        }

        public bool Put(long meetingId, string meeting)
        {
            string workFolderPath = GetWorkFolderPath(meetingId);

            CircularBuffer cb = new CircularBuffer(workFolderPath, WORK_FILE_NAME, _config.MaxWorkFileBackups);
            bool result = cb.WriteLatest(meeting);

            return result;
        }

        private string GetWorkFolderPath(long meetingId)
        {
            return "kjjljkjkj"; // TODO - CA
            ////Meeting meeting = dBOperations.GetMeeting(meetingId);

            ////string workfolderName = dBOperations.GetWorkFolderName(meeting);

            ////string workFolder = Path.Combine(_config.DatafilesPath, workfolderName, SUB_WORK_FOLDER);
            ////return workFolder;
        }

    }
}
