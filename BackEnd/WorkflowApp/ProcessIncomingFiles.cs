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

namespace GM.Workflow
{
    public class ProcessIncomingFiles
    {

        /*   ProcessIncomingFiles watches the "INCOMING" folder for new files and processes them.
         *   Currently the file types can be either PDF or MP4.
         *   The names of the files must be in the format: <country>_<state>_<county>_<town-or-city>_<gov-entity>_<language>_<date>.<extension>
         *   For example:  USA_TX_TravisCounty_Austin_CityCouncil_en_2017-12-14.pdf
         * It creates a work folder in the Datafiles folder based on the name of the file.
         *    For example: USA_TX_TravisCounty_Austin_CityCouncil_en/2017-12-14
         * For new MP4 files, it calls: ProcessRecording
         * For new PDF files, it calls: ProcessTranscript
        */

        AppSettings _config;
        //MeetingInfo _meetingInfo;
        MeetingFolder _meetingFolder;
        TranscriptProcess _processTranscript;
        RecordingProcess _processRecording;

        public ProcessIncomingFiles(
            IOptions<AppSettings> config,
            TranscriptProcess processTranscript,
            RecordingProcess processRecording,
            MeetingFolder meetingFolder
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
        }

        // Watch the incoming folder and process new files as they arrive.
        public void Run()
        {
            string incomingPath = _config.DatafilesPath + @"\INCOMING";
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
            if (!_meetingFolder.SetFields(filename))
            //_meetingInfo = new MeetingInfo(filename);
            //if (!_meetingInfo.valid)
            {
                Console.WriteLine($"ProcessIncomingFiles.cs - filename is invalid: {filename}");
                return;
            }
            string meetingFolder = _config.DatafilesPath + "\\" +_meetingFolder.path;
            string language = _meetingFolder.language;

            // FOR DEVELOPMENT: WE DELETE PRIOR MEETING FOLDER IF IT EXISTS.
            if (_config.IsDevelopment)
            {
                FileDataRepositories.GMFileAccess.DeleteDirectoryAndContents(meetingFolder);

            }

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
                    _processTranscript.ProcessPdf(filename, meetingFolder, language);
                    break;
                case ".txt":
                    _processTranscript.ProcessTxt(filename, meetingFolder, language);
                    break;
                case ".mp4":
                    _processRecording.Process(filename, meetingFolder, language);
                    break;
            }

            // Move the original file to "PROCESSED" folder
            if (_config.MoveIncomingFileAfterProcessing)
            {
                MoveFileToProcessedFolder(filename);
            }
        }

        private void MoveFileToProcessedFolder(string filename)
        {
            string processedPath = _config.DatafilesPath + @"\PROCESSED";
            string newFile = processedPath + "\\" + Path.GetFileName(filename);
            File.Move(filename, newFile);
        }
    }
}
