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
using Microsoft.Extensions.Logging.Abstractions;
using GM.Utilities;
using ChinhDo.Transactions;
using System.Transactions;
using GM.FileDataRepositories;
using GM.DatabaseAccess;

namespace GM.WorkflowApp
{
    public class WF2_ProcessTranscripts
    {
        readonly ILogger<WF2_ProcessTranscripts> logger;
        readonly AppSettings config;
        readonly ITranscriptProcess transcriptProcess;
        readonly IDBOperations dBOperations;

        //readonly IFileRepository fileRepository;

        // This is solely for debugging a unit test issue.
        readonly ILogger<WF2_ProcessTranscripts> loggerReal;

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

            // This is solely for debugging a unit test issue.
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            loggerReal = loggerFactory.CreateLogger<WF2_ProcessTranscripts>();
            loggerReal.LogInformation("REALLOGGER MAIN - WF2_ProcessTranscripts");
        }

        public void Run()
        {
            // 
            bool? isApproved = true;        // We want only the received transcripts that were approved.
            if (!config.RequireManagerApproval) isApproved = null;  // unless the config setting says otherwise.

            List<Meeting> meetings = dBOperations.FindMeetings(SourceType.Transcript, WorkStatus.Received, isApproved);

            foreach (Meeting meeting in meetings)
            {
                    DoWork(meeting);
            }
        }

        private void DoWork(Meeting meeting)
        {
            string workfolderName = dBOperations.GetWorkFolderName(meeting);

            string workFolderPath = Path.Combine(config.DatafilesPath, workfolderName);
            string processedFile = Path.Combine(workFolderPath, WorkfileNames.processedTranscript);

            loggerReal.LogInformation("REALLOGGER MAIN proccesedFilePath={0}", processedFile);

            // For wrapping file database operations in the same transaction
            TxFileManager fileMgr = new TxFileManager();

            using (TransactionScope scope = new TransactionScope())
            {
                meeting.WorkStatus = WorkStatus.Processing;
                meeting.Approved = false;

                dBOperations.WriteChanges();

                scope.Complete();
            }

            string processedOutput = transcriptProcess.Process(meeting.SourceFilename, workFolderPath, meeting.Language);

            using (TransactionScope scope = new TransactionScope())
            {
                fileMgr.WriteAllText(processedFile, processedOutput);
                //File.WriteAllText(processedFile, processedOutput);

                bool existsDatafiles = Directory.Exists(config.DatafilesPath);
                bool existsWorkfolder = Directory.Exists(workFolderPath);
                bool existsSourceFile = File.Exists(Path.Combine(workFolderPath, meeting.SourceFilename));
                bool existsProcessedFile = File.Exists(processedFile);
                loggerReal.LogInformation("REALLOGGER MAIN datafilesPath={0}", config.DatafilesPath);
                loggerReal.LogInformation("REALLOGGER MAIN workFolderPath={0}", workFolderPath);
                loggerReal.LogInformation("REALLOGGER MAIN D={0} W={1} S={3} P={4}",
                    existsDatafiles, existsWorkfolder, existsSourceFile, existsProcessedFile);

                meeting.WorkStatus = WorkStatus.Processed;
                meeting.Approved = false;

                dBOperations.WriteChanges();

                scope.Complete();
            }
        }


    }
}

