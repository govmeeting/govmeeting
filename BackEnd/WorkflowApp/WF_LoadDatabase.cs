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
using GM.LoadDatabase;

namespace GM.Workflow
{
    public class WF_LoadDatabase
    {

        AppSettings config;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;
        ILogger<WF_LoadDatabase> logger;
        //ILoadDatabase loadDatabase;

        public WF_LoadDatabase(
            ILogger<WF_LoadDatabase> _logger,
            IOptions<AppSettings> _config,
            IGovBodyRepository _govBodyRepository,
            IMeetingRepository _meetingRepository
            //ILoadDatabase _loadDatabase
           )
        {
            config = _config.Value;
            logger = _logger;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
            //loadDatabase = _loadDatabase;
        }

        // Find all meetings whose tagging is complete and approved.
        public void Run()
        {

            List<Meeting> meetings = meetingRepository.FindAll(null, WorkStatus.Tagged, true);

            foreach (Meeting meeting in meetings)
            {
                doWork(meeting);
            }

        }

        // Load the data into the database
        public void doWork(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            // TODO - This code is old and needs to be re-written
            // loadDatabase.Process(destFilePath, workFolderPath, language);

        }

    }
}
