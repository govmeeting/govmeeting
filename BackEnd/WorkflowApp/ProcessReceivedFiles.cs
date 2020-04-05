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
    public class ProcessReceivedFiles
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

        ILogger<ProcessReceivedFiles> _logger;
        AppSettings _config;
        IGovBodyRepository _govBodyRepository;
        IMeetingRepository _meetingRepository;

        public ProcessReceivedFiles(
            ILogger<ProcessReceivedFiles> logger,
            IOptions<AppSettings> config,
            IGovBodyRepository govBodyRepository,
            IMeetingRepository meetingRepository
           )
        {
            _logger = logger;
            _config = config.Value;
            _govBodyRepository = govBodyRepository;
            _meetingRepository = meetingRepository;
        }
        public void Run()
        {
            string incomingPath = _config.DatafilesPath + @"\RECEIVED";
            Directory.CreateDirectory(incomingPath);
            
            // Process any existing files in the folder
            foreach (string f in Directory.GetFiles(incomingPath))
            {
                CheckFile(f);
            }

            DirectoryWatcher watcher = new DirectoryWatcher();
            
            // Call "doWork" for new file.
            // TODO - uncomment next line
            //watcher.watch(incomingPath, "", CheckFile);
        }

        public void CheckFile(string filename)
        {
            // TODO - check if a database record was already created for this meeting.
            //   If not, create a record
            // check if it's already been approved. If not, send manager(s) a message

            MeetingFolder meetingFolder = new MeetingFolder(filename);
            //if (!meetingFolder.SetFields(filename))
            if (!meetingFolder.valid)
            {
                // This is not a valid name, skip it.
                string errmsg = $"ProcessIncomingFiles.cs - filename is invalid: {filename}";
                Console.WriteLine(errmsg);
                _logger.LogError(errmsg);
                return;
            }

            // Check if there is a database record for this government body.
            long govBodyId = _govBodyRepository.GetId(
                meetingFolder.country,
                meetingFolder.state,
                meetingFolder.county,
                meetingFolder.municipality);

            // Check if there is database record for this meeting.
            Meeting meeting = _meetingRepository.Get(govBodyId, DateTime.Parse(meetingFolder.date));

            if (!meeting.Approved)
            {
                SendMangerMessage("RECEIVED");
            }
        }

        public void SendMangerMessage(string message)
        {

        }

    }
}
