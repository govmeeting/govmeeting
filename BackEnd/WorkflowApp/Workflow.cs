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
        /*  WorkflowController is the "controller" for the Govmeeting processing steps:
         *  (1) It reads the schedule from the database for retrieving new transcripts or recordings
         *      from online sites. It retrieves new files and stores them in the INCOMING folder.
         *  (2) It watches for new recordings and transcript files that appear in the INCOMING folder and 
         *      performs pre-processing on them. Files can appear because of step 1 above and also
         *      if a user uploads a file via the website or via the phone app for recording a meeting.
         *  (3) When the corrections are completed of the auto voice recognition text,
         *      it transforms the JSON format for the next step in the process: adding tags.
         *  (4) When the addition of tags is completed, it creates a viewable transcript and also
         *      it loads the completed transcript into the database.
         */


        //private readonly ITestService _testService;
        private readonly ILogger<WorkflowController> _logger;
        private readonly AppSettings _config;
        private readonly ProcessIncomingFiles _processIncomingFiles;
        private readonly RetrieveOnlineFiles _retrieveOnlineFiles;
        private readonly ProcessFixedAsr _processFixedAsr;
        private readonly ProcessTagged _processTagged;
        private readonly LoadTranscript _loadTranscript;

        public WorkflowController(
            //ITestService testService,
            IOptions<AppSettings> config,
            ILogger<WorkflowController> logger,
            RetrieveOnlineFiles retrieveOnlineFiles,
            ProcessIncomingFiles processIncomingFiles,
            ProcessFixedAsr processFixedAsr,
            ProcessTagged processTagged,
            LoadTranscript loadTranscript
            )
        {
            //_testService = testService;
            _logger = logger;
            _config = config.Value;
            _retrieveOnlineFiles = retrieveOnlineFiles;
            _processIncomingFiles = processIncomingFiles;
            _processFixedAsr = processFixedAsr;
            _processTagged = processTagged;
            _loadTranscript = loadTranscript;
        }

        public void Run()
        {
            _logger.LogInformation($"Start Workflow - datafilesPath = {_config.DatafilesPath}");

            // Retrieve online recordings and transcripts
            _retrieveOnlineFiles.Run();

            // Process the retrieved files - auto speech recognition of recordings and
            // pre-process transcript files
//            _processIncomingFiles.Run();

            // Process the fixed transcripts to get ready for tagging
            _processFixedAsr.Run();

            // Process tagged transcripts - Create browsable transcript and get ready for loading database
            _processTagged.Run();

            // Load completed transcript data into database
            _loadTranscript.Run();

            System.Console.ReadKey();
        }
    }
}
