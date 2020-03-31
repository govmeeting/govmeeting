using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.LoadDatabase;

namespace GM.Workflow
{

    public class WorkflowController
    {
        //private readonly ITestService _testService;
        private readonly ILogger<WorkflowController> _logger;
        private readonly AppSettings _config;
        private readonly RetrieveOnlineFiles _retrieveOnlineFiles;
        private readonly ProcessReceivedFiles _processReceivedFiles;
        private readonly ProcessRecordings _processRecordings;
        private readonly ProcessTranscripts _processTranscripts;
        private readonly ProcessProofread _processFixedAsr;
        private readonly ProcessTagged _processTagged;
        private readonly ILoadTranscript _loadTranscript;

        public WorkflowController(
            //ITestService testService,
            IOptions<AppSettings> config,
            ILogger<WorkflowController> logger,
            RetrieveOnlineFiles retrieveOnlineFiles,
            ProcessReceivedFiles processReceivedFiles,
            ProcessRecordings processRecordings,
            ProcessTranscripts processTranscripts,
            ProcessProofread processFixedAsr,
            ProcessTagged processTagged,
            ILoadTranscript loadTranscript
            )
        {
            //_testService = testService;
            _logger = logger;
            _config = config.Value;
            _retrieveOnlineFiles = retrieveOnlineFiles;
            _processReceivedFiles = processReceivedFiles;
            _processRecordings = processRecordings;
            _processTranscripts = processTranscripts;
            _processFixedAsr = processFixedAsr;
            _processTagged = processTagged;
            _loadTranscript = loadTranscript;
        }

        public void Run()
        {
            _logger.LogInformation($"Start Workflow - datafilesPath = {_config.DatafilesPath}");

            //string testfilesPath = _config.TestfilesPath;
            //string datafilesPath = _config.DatafilesPath;
            //InitializeFileTestData.CopyTestData(testfilesPath, datafilesPath);

            // Retreive online transcripts or recordings
            _retrieveOnlineFiles.Run();

            // Process received files
            _processReceivedFiles.Run();

            // Process new recordings - auto speech recognition
//            _processRecordings.Run();

            // Processing new transcript files
            _processTranscripts.Run();

            // Process the proofread transcripts to get ready for tagging
            _processFixedAsr.Run();

            // Process tagged transcripts to be ready for viewing
            _processTagged.Run();

            // Load completed transcript data into database
            _loadTranscript.Run();

            System.Console.ReadKey();
        }
    }
}
