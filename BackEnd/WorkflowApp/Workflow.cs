using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GM.Configuration;
//using GM.LoadDatabase;

namespace GM.WorkflowApp
{

    public class WorkflowController
    {
        //private readonly ITestService _testService;
        private readonly ILogger<WorkflowController> logger;
        private readonly AppSettings config;
        private readonly WF1_RetrieveOnlineFiles wf_retrieveOnlineFiles;
        private readonly WF3_TranscribeRecordings wf_processRecordings;
        private readonly WF2_ProcessTranscripts wf_processTranscripts;
        private readonly WF5_EditTranscriptions wf_processTagged;
        private readonly WF7_LoadDatabase wf_loadDatabase;

        public WorkflowController(
            //ITestService testService,
            IOptions<AppSettings> _config,
            ILogger<WorkflowController> _logger,
            WF1_RetrieveOnlineFiles _wf_retrieveOnlineFiles,
            WF3_TranscribeRecordings _wf_processRecordings,
            WF2_ProcessTranscripts _wf_processTranscripts,
            WF5_EditTranscriptions _wf_processTagged,
            WF7_LoadDatabase _wf_loadDatabase
            )
        {
            //_testService = testService;
            logger = _logger;
            config = _config.Value;
            wf_retrieveOnlineFiles = _wf_retrieveOnlineFiles;
            wf_processRecordings = _wf_processRecordings;
            wf_processTranscripts = _wf_processTranscripts;
            wf_processTagged = _wf_processTagged;
            wf_loadDatabase = _wf_loadDatabase;
        }

        public void Run()
        {
            logger.LogInformation($"Start Workflow - datafilesPath = {config.DatafilesPath}");

            // Retreive online transcripts or recordings
            wf_retrieveOnlineFiles.Run();

            // Process new recordings - auto speech recognition
            wf_processRecordings.Run();

            // Processing new transcript files
            wf_processTranscripts.Run();

            // Process tagged transcripts to be ready for viewing
            wf_processTagged.Run();

            // Load completed transcript data into database
            wf_loadDatabase.Run();

            if (config.ExitAfterOnceThroughWorkflow)
            {
                return;
            }
        }
    }
}
