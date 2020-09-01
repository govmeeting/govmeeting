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
using GM.DatabaseAccess;

namespace GM.Workflow
{
    public class WF7_LoadDatabase
    {
        readonly ILogger<WF7_LoadDatabase> logger;
        readonly AppSettings config;
        readonly IDBOperations dBOperations;

        public WF7_LoadDatabase(
            ILogger<WF7_LoadDatabase> _logger,
            IOptions<AppSettings> _config,
            IDBOperations _dBOperations
           )
        {
            config = _config.Value;
            logger = _logger;
            dBOperations = _dBOperations;
        }

        // Find all meetings whose tagging is complete and approved.
        public void Run()
        {

            List<Meeting> meetings = dBOperations.FindMeetings(null, WorkStatus.Tagged, true);

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
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meeting.WorkFolder;

            // TODO - This code is old and needs to be re-written
            // loadDatabase.Process(destFilePath, workFolderPath, language);

        }

    }
}
