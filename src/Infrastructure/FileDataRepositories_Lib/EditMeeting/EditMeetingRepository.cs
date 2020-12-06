using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.ViewModels;
//using GM.DatabaseRepositories;

namespace GM.FileDataRepositories
{
    public class EditMeetingRepository : IEditMeetingRepository
    {
        // We use a "circular buffer" to store the work files. The base name of the WORK_FILE will
        // be appended with a sequence number each time a new revision is stored.
        // The GetLatest and WriteLatest methods on on this buffer will return or store the latest revision.

        const string WORK_FOLDER_NAME = "Fixasr";
        const string WORK_FILE_NAME = "ToFix.json";

        private readonly AppSettings config;
        private readonly string datafiles;

        public EditMeetingRepository(
            IOptions<AppSettings> _config
            )
        {
            config = _config.Value;
            datafiles = config.DatafilesPath;
        }

        public string Get(long meetingId, int part)
        {
            // TODO - Remove later - for development: If the data is not in Datafiles folder, copy it from testdata.
            // UseTestData.CopyIfNeeded(workFolder, _config.DatafilesPath, _config.TestfilesPath);

            string partFolder = GetPartFolder(meetingId, part);

            CircularBuffer cb = new CircularBuffer(partFolder, WORK_FILE_NAME, config.MaxWorkFileBackups);
            string latestFixes = cb.GetLatest();

            //MeetingEditDto fixasr = JsonConvert.DeserializeObject<MeetingEditDto>(latestFixes);
            return latestFixes;
        }

        public bool Put(string value, long meetingId, int part)
        {
            string partFolder = GetPartFolder(meetingId, part);
            //string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            CircularBuffer cb = new CircularBuffer(partFolder, WORK_FILE_NAME, config.MaxWorkFileBackups);
            bool success = cb.WriteLatest(value);

            return success;
        }

        private string GetPartFolder(long meetingId, int part)
        {
            //string meetingFolderPath = meetingFolder.GetNameFromId(meetingId);
            string workFolderPath = GetWorkFolderPath(meetingId);

            //string workFolder = meetingFolderPath + "\\" + WORK_FOLDER_NAME;
            string partFolder = workFolderPath + $"\\part{part:D2}";
            string partFolderPath = Path.Combine(datafiles, partFolder);

            return partFolderPath;
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

