using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.ProcessRecording;
using GM.ProcessTranscript;
using GM.ViewModels;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using GM.DatabaseModel;
using Microsoft.Extensions.Logging;
using GM.Utilities;
using GM.EditTranscript;
using GM.DatabaseAccess;


namespace GM.Workflow
{
    public class WF3_TranscribeRecordings
    {
        readonly ILogger<WF3_TranscribeRecordings> logger;
        readonly AppSettings config;
        readonly RecordingProcess processRecording;
        readonly IDBOperations dBOperations;
        readonly WorkSegments workSegments = new WorkSegments();

        public WF3_TranscribeRecordings(
            ILogger<WF3_TranscribeRecordings> _logger,
            IOptions<AppSettings> _config,
            RecordingProcess _processRecording,
            IDBOperations _dBOperations
           )
        {
            config = _config.Value;

            logger = _logger;
            processRecording = _processRecording;
            dBOperations = _dBOperations;
        }

        // Find all new received meetings whose source is a recording and approved status is true.
        public void Run()
        {
            // Do we need manager approval?
            bool? approved = true;
            if (!config.RequireManagerApproval) approved = null;
            List<Meeting> meetings;

            meetings = dBOperations.FindMeetings(SourceType.Recording, WorkStatus.Received, approved);
            foreach (Meeting meeting in meetings)
            {
                TranscribeRecording(meeting);
            }
        }

        // Create a work folder in DATAFILES/PROCESSING and process the recording
        private void TranscribeRecording(Meeting meeting)
        {
            meeting.WorkStatus = WorkStatus.Transcribing;

            // Create workfolder
            string workfolderPath = GetWorkfolderPath(meeting);
            if (!CreateWorkfolder(workfolderPath))
            {
                return;
            }

            // transcribe recording
            string sourceFilePath = config.DatafilesPath + "\\RECEIVED\\" + meeting.SourceFilename;
            processRecording.Process(sourceFilePath, workfolderPath, meeting.Language);

            meeting.WorkStatus = WorkStatus.Transcribed;

            // if true, editing will be allowed to proceed automatically.
            // set to false to require manager approval.
            meeting.Approved = true;
        }


        private string GetWorkfolderPath(Meeting meeting)
        {
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meeting.WorkFolder;

            return workFolderPath;
        }

        private bool CreateWorkfolder(string workFolderPath)
        {
            if (!GMFileAccess.CreateDirectory(workFolderPath))
            {
                Console.WriteLine($"ProcessRecordings - ERROR: could not create meeting folder {workFolderPath}");
                return false;
            }
            return true;
        }
    }
}
