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
    public class WF_ProcessTranscripts
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

        AppSettings config;
        TranscriptProcess transcriptProcess;
        IMeetingRepository meetingRepository;
        IGovBodyRepository govBodyRepository;
        ILogger<WF_ProcessReceivedFiles> logger;

        public WF_ProcessTranscripts(
            ILogger<WF_ProcessReceivedFiles> _logger,
            IOptions<AppSettings> _config,
            TranscriptProcess _transcriptProcess,
            IMeetingRepository _meetingRepository,
            IGovBodyRepository _govBodyRepository
           )
        {
            logger = _logger;
            config = _config.Value;
            transcriptProcess = _transcriptProcess;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        // Watch the incoming folder and process new files as they arrive.
        public void Run()
        {

            List<Meeting> meetings = meetingRepository.FindAll(SourceType.Transcript, WorkStatus.Received, true);

            foreach (Meeting meeting in meetings)
            {
                    doWork(meeting);
            }

        }

        public void doWork(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;


            if (!FileDataRepositories.GMFileAccess.CreateDirectory(workFolderPath))
            {
                // We were not able to create a folder for processing this video.
                // Probably because the folder already exists.
                Console.WriteLine("ProcessTranscriptsFiles.cs - ERROR: could not create work folder");
                return;
            }

            string sourceFilePath = config.DatafilesPath + "\\RECEIVED\\" + meeting.SourceFilename;
            string destFilePath = config.DatafilesPath + "\\PROCESSING\\" + meeting.SourceFilename;
            if (File.Exists(destFilePath))
            {
                logger.LogError("File already exists: ${destFilePath}");
            }
            else
            {
                File.Move(sourceFilePath, destFilePath);
            }


            transcriptProcess.Process(destFilePath, workFolderPath, meetingFolder.language);
        }
    }
}
