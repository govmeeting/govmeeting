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
using GM.DatabaseRepositories;
using GM.DatabaseModel;
using Microsoft.Extensions.Logging;

namespace GM.Workflow
{
    public class WF_ProcessRecordings
    {
        AppSettings config;
        RecordingProcess processRecording;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;
        ILogger<WF_ProcessReceivedFiles> logger;

        public WF_ProcessRecordings(
            ILogger<WF_ProcessReceivedFiles> _logger,
            IOptions<AppSettings> _config,
            RecordingProcess _processRecording,
            IGovBodyRepository _govBodyRepository,
            IMeetingRepository _meetingRepository
           )
        {
            config = _config.Value;

            // Google Cloud libraries automatically use the environment variable GOOGLE_APPLICATION_CREDENTIALS
            // to authenticate to Google Cloud. Here we set this variable to the path of the credentials file,
            // which is defined in app.settings.json.
            string credentialsFilePath = config.GoogleApplicationCredentials;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);

            logger = _logger;
            processRecording = _processRecording;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        // Find all new received meetings whose source is a recording and approved status is true.
        public void Run()
        {

            List<Meeting> meetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Received, true);

            foreach (Meeting meeting in meetings)
            {
                doWork(meeting);
            }

        }

        // Create a work folder in Datafiles/PROCESSING and process the recording
        public void doWork(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            if (!FileDataRepositories.GMFileAccess.CreateDirectory(workFolderPath))
            {
                Console.WriteLine($"ProcessRecordings - ERROR: could not create meeting folder {workFolderPath}");
                return;
            }

            // Move source file to the PROCESSING folder
            string sourceFilePath = config.DatafilesPath + "\\RECEIVED\\" + meeting.SourceFilename;
            string destFilePath = config.DatafilesPath + "\\PROCESSING\\" + meeting.SourceFilename;
            if (File.Exists(destFilePath))
            {
                logger.LogError("File already exists: ${destFilePath}");
            }
            else {
                File.Move(sourceFilePath, destFilePath);
            }

            processRecording.Process(destFilePath, workFolderPath, meetingFolder.language);

        }
    }
}
