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


namespace GM.WorkflowApp
{
    public class WF3_Transcribe
    {
        readonly ILogger<WF3_Transcribe> logger;
        readonly AppSettings config;
        readonly IRecordingProcess processRecording;
        readonly IDBOperations dBOperations;
        readonly WorkSegments workSegments = new WorkSegments();

        public WF3_Transcribe(
            ILogger<WF3_Transcribe> _logger,
            IOptions<AppSettings> _config,
            IRecordingProcess _processRecording,
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

            // transcribe recording
            string sourceFilePath = Path.Combine(workfolderPath, meeting.SourceFilename);
            processRecording.Process(sourceFilePath, workfolderPath, meeting.Language);

            meeting.WorkStatus = WorkStatus.Transcribed;

            // if true, editing will be allowed to proceed automatically.
            // set to false to require manager approval.
            meeting.Approved = true;
        }


        private string GetWorkfolderPath(Meeting meeting)
        {
            string workfolderName = dBOperations.GetWorkFolderName(meeting);
            string workFolderPath = config.DatafilesPath + workfolderName;
            return workFolderPath;
        }

        //private bool CreateWorkfolder(string workFolderPath)
        //{
        //    if (!GMFileAccess.CreateDirectory(workFolderPath))
        //    {
        //        Console.WriteLine($"ProcessRecordings - ERROR: could not create meeting folder {workFolderPath}");
        //        return false;
        //    }
        //    return true;
        //}
    }
}
