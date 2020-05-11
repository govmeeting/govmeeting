using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using GM.DatabaseRepositories;
using GM.DatabaseModel;

namespace GM.Workflow
{
    public class WF_RetrieveOnlineFiles
    {
        // TODO - IMPLEMENT THIS CLASS
        
        /* RetrieveOnlineFiles will:
         * Read the meeting schedules for all government bodies in the database.
         * 1. If a current meeting may have taken place, it will:
         *    Check the website where either its transcript or a recording may be found.
         *    If found it will:
         * 2. Start the file retrieval.
         * 3. Store the retieved file in the "DATAFILES/RECEIVED" folder.
         * Repeat for each government body.
         *
         *  Files can also be placed in the RECEIVED folder by the phone app for recording a meeting.
         *  Files that are uploaded by a registered user are also placed in the RECEIVED folder.
         */

        AppSettings _config;
        IGovBodyRepository _govBodyRepository;
        IMeetingRepository _meetingRepository;

        public WF_RetrieveOnlineFiles(
            IOptions<AppSettings> config,
            IGovBodyRepository govBodyRepository,
            IMeetingRepository meetingRepository
           )
        {
            _config = config.Value;
            _govBodyRepository = govBodyRepository;
            _meetingRepository = meetingRepository;
        }
        public void Run()
        {
            string incomingPath = _config.DatafilesPath + @"\RECEIVED";
            Directory.CreateDirectory(incomingPath);
            
            RetrieveNewFiles(incomingPath);

        }

        public void RetrieveNewFiles(string incomingPath)
        {
            // TODO - read schedules in database and check for new files to retrieve.
            // throw new NotImplementedException();
        }
    }
}
