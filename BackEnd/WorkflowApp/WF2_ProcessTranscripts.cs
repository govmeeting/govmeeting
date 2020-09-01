using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using GM.ProcessRecording;
using GM.ProcessTranscript;
using GM.ViewModels;
using Microsoft.Extensions.Options;
using GM.Configuration;
//using GM.FileDataRepositories;
using GM.DatabaseModel;
using Microsoft.Extensions.Logging;
using GM.Utilities;
using ChinhDo.Transactions;
using System.Transactions;
using GM.FileDataRepositories;
using GM.DatabaseAccess;

namespace GM.Workflow
{
    public class WF2_ProcessTranscripts
    {
        readonly ILogger<WF2_ProcessTranscripts> logger;
        readonly AppSettings config;
        readonly ITranscriptProcess transcriptProcess;
        readonly IDBOperations dBOperations;
        //readonly IFileRepository fileRepository;

        public WF2_ProcessTranscripts(
            ILogger<WF2_ProcessTranscripts> _logger,
            IOptions<AppSettings> _config,
            ITranscriptProcess _transcriptProcess,
            IDBOperations _dBOperations
            //IFileRepository _fileRepository
           )
        {
            logger = _logger;
            config = _config.Value;
            transcriptProcess = _transcriptProcess;
            dBOperations = _dBOperations;
            //fileRepository = _fileRepository;
        }

        public void Run()
        {
            // 
            bool? isApproved = true;        // We want the received transcripts that were approved.
            if (!config.RequireManagerApproval) isApproved = null;  // unless config setting says otherwise.
            List<Meeting> meetings = dBOperations.FindMeetings(SourceType.Transcript, WorkStatus.Received, isApproved);

            foreach (Meeting meeting in meetings)
            {
                    DoWork(meeting);
            }

        }

        private void DoWork(Meeting meeting)
        {
            string workFolderPath = Path.Combine(config.DatafilesPath, meeting.WorkFolder);
            //string sourceFilePath = Path.Combine(workFolderPath, meeting.SourceFilename);
            string processedFilePath = Path.Combine(workFolderPath, WorkfileNames.processedTranscript);

            // If the workfolder exists, it most likely means the system crashed while trying to
            // process this meeting earlier. Remove the folder and try again.
            //if (Directory.Exists(workFolderPath))
            //{
            //    GMFileAccess.DeleteDirectoryAndContents(workFolderPath);
            //}

            // Wrap the file and database operations in the same transaction
            TxFileManager fileMgr = new TxFileManager();
            using (TransactionScope scope = new TransactionScope())
            {

                //fileMgr.CreateDirectory(workFolderPath);

                meeting.WorkStatus = WorkStatus.Processing;
                meeting.Approved = false;

                dBOperations.WriteChanges();

                scope.Complete();
            }

            string processedOutput = transcriptProcess.Process(meeting.SourceFilename, workFolderPath, meeting.Language);

            using (TransactionScope scope = new TransactionScope())
            {

                fileMgr.WriteAllText(processedFilePath, processedOutput);

                meeting.WorkStatus = WorkStatus.Processed;
                meeting.Approved = false;

                dBOperations.WriteChanges();

                scope.Complete();
            }
        }


    }
}

