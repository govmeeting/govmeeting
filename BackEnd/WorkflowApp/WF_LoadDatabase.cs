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
    public class WF_LoadDatabase
    {
        readonly AppSettings config;
        readonly IMeetingRepository meetingRepository;
        readonly ILogger<WF_LoadDatabase> logger;
        //IGovBodyRepository govBodyRepository;
        //ILoadDatabase loadDatabase;

        public WF_LoadDatabase(
            ILogger<WF_LoadDatabase> _logger,
            IOptions<AppSettings> _config,
            IMeetingRepository _meetingRepository
           //IGovBodyRepository _govBodyRepository,
           //ILoadDatabase _loadDatabase
           )
        {
            config = _config.Value;
            logger = _logger;
            meetingRepository = _meetingRepository;
            //govBodyRepository = _govBodyRepository;
            //loadDatabase = _loadDatabase;
        }

        // Find all meetings whose tagging is complete and approved.
        public void Run()
        {

            List<Meeting> meetings = meetingRepository.FindAll(null, WorkStatus.Tagged, true);

            foreach (Meeting meeting in meetings)
            {
                DoWork(meeting);
            }

        }

        // Load the data into the database
        public void DoWork(Meeting meeting)
        {
            // Get the work folder path
            //MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workfolder = meetingRepository.GetLongName(meeting.Id);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + workfolder;

            // TODO - This code is old and needs to be re-written
            // loadDatabase.Process(destFilePath, workFolderPath, language);

        }

    }
}
