using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GM.Configuration;
//using GM.LoadDatabase;

namespace GM.Workflow
{

    public class WorkflowController
    {
        //private readonly ITestService _testService;
        private readonly ILogger<WorkflowController> logger;
        private readonly AppSettings config;
        private readonly WF_RetrieveOnlineFiles wf_retrieveOnlineFiles;
        private readonly WF_ProcessReceivedFiles wf_processReceivedFiles;
        private readonly WF_ProcessRecordings wf_processRecordings;
        private readonly WF_ProcessTranscripts wf_processTranscripts;
        private readonly WF_ProcessProofread wf_processFixedAsr;
        private readonly WF_ProcessTagged wf_processTagged;
        private readonly WF_LoadDatabase wf_loadDatabase;

        public WorkflowController(
            //ITestService testService,
            IOptions<AppSettings> _config,
            ILogger<WorkflowController> _logger,
            WF_RetrieveOnlineFiles _wf_retrieveOnlineFiles,
            WF_ProcessReceivedFiles _wf_processReceivedFiles,
            WF_ProcessRecordings _wf_processRecordings,
            WF_ProcessTranscripts _wf_processTranscripts,
            WF_ProcessProofread _wf_processProofread,
            WF_ProcessTagged _wf_processTagged,
            WF_LoadDatabase _wf_loadDatabase
            )
        {
            //_testService = testService;
            logger = _logger;
            config = _config.Value;
            wf_retrieveOnlineFiles = _wf_retrieveOnlineFiles;
            wf_processReceivedFiles = _wf_processReceivedFiles;
            wf_processRecordings = _wf_processRecordings;
            wf_processTranscripts = _wf_processTranscripts;
            wf_processFixedAsr = _wf_processProofread;
            wf_processTagged = _wf_processTagged;
            wf_loadDatabase = _wf_loadDatabase;
        }

        public void Run()
        {
            logger.LogInformation($"Start Workflow - datafilesPath = {config.DatafilesPath}");

            // Retreive online transcripts or recordings
            wf_retrieveOnlineFiles.Run();

            // Process received files
            wf_processReceivedFiles.Run();

            // Process new recordings - auto speech recognition
            // wf_processRecordings.Run();

            // Processing new transcript files
            wf_processTranscripts.Run();

            // Process the proofread transcripts to get ready for tagging
            wf_processFixedAsr.Run();

            // Process tagged transcripts to be ready for viewing
            wf_processTagged.Run();

            // Load completed transcript data into database
            wf_loadDatabase.Run();

            if (config.ExitAfterOnceThroughWorkflow)
            {
                // For Debugging
                System.Console.ReadKey();

                return;
            }
        }
    }
}
