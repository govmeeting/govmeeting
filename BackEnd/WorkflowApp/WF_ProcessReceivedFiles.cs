using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using GM.DatabaseRepositories;
using GM.DatabaseModel;

namespace GM.Workflow
{
    public class WF_ProcessReceivedFiles
    {
        // TODO - IMPLEMENT THIS CLASS

        /* ProcessReceivedFiles - For each new file, create database record and send message to manager(s)
         * 
         * This processes files in the Datafiles\RECEIVED folder.
         * It will create a "Meeting" record in the database for those which do not yet have one.
         *  Files can be placed in the RECEIVED folder by:
         *      the RetrieveOnlineFile component
         *      the phone app for recording a meeting.
         *      being uploaded by a registered user
         */

        ILogger<WF_ProcessReceivedFiles> logger;
        AppSettings config;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;

        public WF_ProcessReceivedFiles(
            ILogger<WF_ProcessReceivedFiles> _logger,
            IOptions<AppSettings> _config,
            IGovBodyRepository _govBodyRepository,
            IMeetingRepository _meetingRepository
           )
        {
            logger = _logger;
            config = _config.Value;
            govBodyRepository = _govBodyRepository;
            meetingRepository = _meetingRepository;
        }
        public void Run()
        {
            string incomingPath = config.DatafilesPath + @"\RECEIVED";
            Directory.CreateDirectory(incomingPath);
            
            // Process any existing files in the folder
            foreach (string f in Directory.GetFiles(incomingPath))
            {
                CheckFile(f);
            }

            DirectoryWatcher watcher = new DirectoryWatcher();
            // TODO - uncomment next line
            //watcher.watch(incomingPath, "", CheckFile);
        }

        public void CheckFile(string filename)
        {
            // Obtain the meeting work folder path from the input filename.
            MeetingFolder meetingFolder = new MeetingFolder(filename);
            if (!meetingFolder.valid)
            {
                // This is not a valid name, skip it.
                string errmsg = $"ProcessIncomingFiles.cs - filename is invalid: {filename}";
                Console.WriteLine(errmsg);
                logger.LogError(errmsg);
                return;
            }

            // Check if there is a database record for this government body.
            long govBodyId = govBodyRepository.GetId(
                meetingFolder.country,
                meetingFolder.state,
                meetingFolder.county,
                meetingFolder.municipality);

            // Check if there is database record for this meeting.
            Meeting meeting = meetingRepository.Get(govBodyId, DateTime.Parse(meetingFolder.date));

            if (!meeting.Approved)
            {
                SendMangerMessage("RECEIVED");
            }
        }

        public void SendMangerMessage(string message)
        {
            // TODO - Implement
        }

    }
}
