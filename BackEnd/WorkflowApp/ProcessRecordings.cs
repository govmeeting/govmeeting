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

namespace GM.Workflow
{
    public class ProcessRecordings
    {
        AppSettings config;
        RecordingProcess processRecording;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;

        public ProcessRecordings(
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
            GovernmentBody g = govBodyRepository.Get(meeting.GovernmentBodyId);
            string language = g.Languages[0].Name;

            MeetingFolder meetingFolder = new MeetingFolder(g.Country, g.State, g.County, g.Municipality, meeting.Date, g.Name, language);

            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            if (!FileDataRepositories.GMFileAccess.CreateDirectory(workFolderPath))
            {
                Console.WriteLine($"ProcessRecordings - ERROR: could not create meeting folder {workFolderPath}");
                return;
            }

            string sourceFilePath = config.DatafilesPath + "\\RECEIVED\\" + meeting.SourceFilename;
            processRecording.Process(sourceFilePath, workFolderPath, language);

        }

        //private void MoveFileToProcessedFolder(string filename)
        //{
        //    string processedPath = _config.DatafilesPath + @"\COMPLETED";
        //    string newFile = processedPath + "\\" + Path.GetFileName(filename);
        //    File.Move(filename, newFile);
        //}
    }
}
