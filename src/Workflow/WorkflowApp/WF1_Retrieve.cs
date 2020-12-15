using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
//using GM.DatabaseRepositories;
using System.Collections.Generic;
using System.ComponentModel;
////using GM.DatabaseAccess;
using Microsoft.Extensions.Logging;
using System.Linq;
using GM.GetOnlineFiles;
using System.Transactions;
using ChinhDo.Transactions;

using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;


namespace GM.WorkflowApp
{
    public class WF1_Retrieve
    {
        // TODO - IMPLEMENT THIS CLASS

        /*   ===== RetrieveOnlineFiles will:
         * Read the meeting schedules of each Govbody in the database.
         * If a current meeting may have taken place, it will:
         *    Check the website where either its transcript or a recording may be found.
         *    If found it will:
         * Start the file retrieval.
         * Store the retieved file in the "DATAFILES/RECEIVED" folder.
         * Create a new Meeting record for the Govbody
         * Set the Meeting WorkStatus property to "Received"
         * Set the Meeting Approved property to false".
         * Send the Govbody managers a "RECEIVED" message.
         * Repeat for each government body.
         *
         *  New meetings can also added to a Govbody by:
         *      * the phone app for recording a meeting
         *      * a file being uploaded by a registered user with appropriate rights.
         */

        readonly ILogger<WF1_Retrieve> logger;
        readonly AppSettings config;
        ////readonly IDBOperations dBOperations;
        readonly IRetrieveNewFiles retrieveNewFiles;

        public WF1_Retrieve(
            ILogger<WF1_Retrieve> _logger,
            IOptions<AppSettings> _config,
            ////IDBOperations _dBOperations,
            IRetrieveNewFiles _retrieveNewFiles
           )
        {
            logger = _logger;
            config = _config.Value;
            ////dBOperations = _dBOperations;
            retrieveNewFiles = _retrieveNewFiles;
        }

        public void Run()
        {
            ////List<Govbody> govBodies = dBOperations.FindGovBodiesWithScheduledMeetings();
            List<Govbody> govBodies = new List<Govbody>();  // TODO - implement

            foreach (Govbody govBody in govBodies)
            {
                DoWork(govBody);
            }
        }

        private void DoWork(Govbody govBody)
        {
            //List<ScheduledMeeting> scheduled = govBody.ScheduledMeetings;
            IReadOnlyCollection<ScheduledMeeting> scheduled = govBody.ScheduledMeetings;

            // Get all meetings that have should occured
            IEnumerable<ScheduledMeeting> results = scheduled.Where(
                s => s.Date < (DateTime.Now));

            foreach (ScheduledMeeting result in results)
            {
                DateTime actualDate;
                SourceType type;

                // Do actual retrieval
                string retrievedFile = retrieveNewFiles.RetrieveFile(govBody, result.Date, out actualDate, out type);

                // create a work folder for this meeting
                string workfolderName = govBody.LongName + "_" + actualDate.ToString("yyyy-MM-dd");
                string workFolderPath = Path.Combine(config.DatafilesPath, workfolderName);

                string extension = Path.GetExtension(retrievedFile);
                string sourceFilename = "source" + extension;
                string sourceFilePath = Path.Combine(workFolderPath, sourceFilename);

                // Create the meeting record
                Meeting meeting = new Meeting(actualDate, type, sourceFilename);
                meeting.WorkStatus = WorkStatus.Received;
                meeting.Approved = false;

                TxFileManager fileMgr = new TxFileManager();
                using (TransactionScope scope = new TransactionScope())

                {
                    Directory.CreateDirectory(workFolderPath);
                    fileMgr.Copy(retrievedFile, sourceFilePath, true);
                    //// TODO - implement
                    ////dBOperations.Add(meeting);
                    ////dBOperations.WriteChanges();
                    scope.Complete();
                }

            }
        }

    }
}
