using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.ProcessRecording;
using GM.ProcessTranscript;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using Microsoft.Extensions.Logging;
using GM.Utilities;
using GM.EditTranscript;
using System.Transactions;

using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;


namespace GM.WorkflowApp
{
    public class WF3_Transcribe
    {
        readonly ILogger<WF3_Transcribe> logger;
        readonly AppSettings config;
        readonly IRecordingProcess processRecording;
        ////readonly IDBOperations dBOperations;
        readonly IFileRepository fileRepository;
        readonly WorkSegments workSegments = new WorkSegments();

        public WF3_Transcribe(
            ILogger<WF3_Transcribe> _logger,
            IOptions<AppSettings> _config,
            IRecordingProcess _processRecording,
            ////IDBOperations _dBOperations,
            IFileRepository _fileRepository
           )
        {
            logger = _logger;
            config = _config.Value;
            processRecording = _processRecording;
            ////dBOperations = _dBOperations;
            fileRepository = _fileRepository;
        }

        // Find all new received meetings whose source is a recording and approved status is true.
        public void Run()
        {
            // Do we need manager approval?
            bool? approved = true;
            if (!config.RequireManagerApproval) approved = null;
            List<Meeting> meetings;

            ////meetings = dBOperations.FindMeetings(SourceType.Recording, WorkStatus.Received, approved);
            meetings = new List<Meeting>();   // TODO - CA

            foreach (Meeting meeting in meetings)
            {
                TranscribeRecording(meeting);
            }
        }

        private void TranscribeRecording(Meeting meeting)
        {
            string workfolderPath = fileRepository.WorkfolderPath(meeting);
            string sourcefilePath = fileRepository.SourcefilePath(meeting);

            using TransactionScope scope = new TransactionScope();
            meeting.WorkStatus = WorkStatus.Transcribing;

            // transcribe recording
            processRecording.Process(sourcefilePath, workfolderPath, meeting.Language);

            meeting.WorkStatus = WorkStatus.Transcribed;

            // if true, editing will be allowed to proceed automatically.
            // set to false to require manager approval.
            meeting.Approved = true;

            ////dBOperations.WriteChanges();
            scope.Complete();
        }
    }
}
