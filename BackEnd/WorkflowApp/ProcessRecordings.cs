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

        /*   ProcessIncomingFiles watches the "RECEIVED" folder for files to be processed.
         *   Currently the file types can be either PDF or MP4.
         *   The names of the files must be in the format: <country>_<state>_<county>_<town-or-city>_<gov-entity>_<language>_<date>.<extension>
         *   For example:  USA_TX_TravisCounty_Austin_CityCouncil_en_2017-12-14.pdf
         * It creates a work folder in the Datafiles folder based on the name of the file.
         *    For example: USA_TX_TravisCounty_Austin_CityCouncil_en/2017-12-14
         * For new MP4 files, it calls: ProcessRecording
         * For new PDF files, it calls: ProcessTranscript
        */

        AppSettings _config;
        MeetingFolder _meetingFolder;
        TranscriptProcess _processTranscript;
        RecordingProcess _processRecording;
        IMeetingRepository _meetingRepository;
        IGovBodyRepository _govBodyRepository;

        public ProcessRecordings(
            IOptions<AppSettings> config,
            TranscriptProcess processTranscript,
            RecordingProcess processRecording,
            MeetingFolder meetingFolder,
            IMeetingRepository meetingRepository,
            IGovBodyRepository govBodyRepository
           )
        {
            _config = config.Value;

            // Google Cloud libraries automatically use the environment variable GOOGLE_APPLICATION_CREDENTIALS
            // to authenticate to Google Cloud. Here we set this variable to the path of the credentials file,
            // which is defined in app.settings.json.
            string credentialsFilePath = _config.GoogleApplicationCredentials;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);

            _meetingFolder = meetingFolder;
            _processTranscript = processTranscript;
            _processRecording = processRecording;
            _meetingRepository = meetingRepository;
            _govBodyRepository = govBodyRepository;
        }

        // Watch the incoming folder and process new files as they arrive.
        public void Run()
        {
            string incomingPath = _config.DatafilesPath + @"\RECEIVED";
            Directory.CreateDirectory(incomingPath);

            // Process any existing files in the folder
            foreach (string f in Directory.GetFiles(incomingPath))
            {
                doWork(f);
            }

            DirectoryWatcher watcher = new DirectoryWatcher();

            // Call "doWork" for new file.
            watcher.watch(incomingPath, "", doWork);
        }

        public void doWork(string filename)
        {
            // Create a MeetingInfo instance. This takes the info in the filename string, for example,
            // "USA_TX_TravisCounty_Austin_CityCouncil_en/2017-12-14" and puts it into a strongly typed object.
            if (!_meetingFolder.SetFields(filename))
            {
                // If this is not a valid name, skip it.
                Console.WriteLine($"ProcessIncomingFiles.cs - filename is invalid: {filename}");
                return;
            }

            // Check if there is a database record for this government body.
            long govBodyId = _govBodyRepository.GetId(
                _meetingFolder.country,
                _meetingFolder.state,
                _meetingFolder.county,
                _meetingFolder.municipality);

            // Check if there is database record for this meeting.
            //long Id = _meetingFolder.GetId();
            Meeting meeting = _meetingRepository.Get(govBodyId, DateTime.Parse(_meetingFolder.date));


            string meetingFolder = _config.DatafilesPath + "\\PROCESSING\\" + _meetingFolder.path;
            string language = _meetingFolder.language;

            // FOR DEVELOPMENT: WE DELETE PRIOR MEETING FOLDER IF IT EXISTS.
            //if (_config.IsDevelopment)
            //{
            //    FileDataRepositories.GMFileAccess.DeleteDirectoryAndContents(meetingFolder);

            //}

            if (!FileDataRepositories.GMFileAccess.CreateDirectory(meetingFolder))
            {
                // We were not able to create a folder for processing this video.
                // Probably because the folder already exists.
                Console.WriteLine("ProcessIncomingFiles.cs - ERROR: could not create meeting folder");
                return;
            }

            FileInfo file = new FileInfo(filename);
            string extension = file.Extension;
            switch (extension)
            {
                case ".pdf":
                case ".txt":
                    _processTranscript.Process(filename, meetingFolder, language);
                    break;
                case ".mp4":
                    _processRecording.Process(filename, meetingFolder, language);
                    break;
            }

            // Move the original file to "COMPLETED" folder
            if (_config.MoveIncomingFileAfterProcessing)
            {
                MoveFileToProcessedFolder(filename);
            }
        }

        private void MoveFileToProcessedFolder(string filename)
        {
            string processedPath = _config.DatafilesPath + @"\COMPLETED";
            string newFile = processedPath + "\\" + Path.GetFileName(filename);
            File.Move(filename, newFile);
        }
    }
}
