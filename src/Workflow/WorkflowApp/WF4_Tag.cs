using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.FileDataRepositories;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using GM.Utilities;
using GM.DatabaseAccess;

using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;


namespace GM.WorkflowApp
{
    public class WF4_Tag
    {
        // TODO - IMPLEMENT THIS CLASS

        /* This is the tiird step in handling existing transcripts that are produced by the government body.
         * The first step is to retrieve the online transcript, which is done in WF_RetrieveOnlineFiles.
         * The second step is to automatically process the transcript, which is done in WF_ProcessTranscripts.
         * This step "WF_TagTranscripts" handles the manual tagging of the processed transcripts.
         * 
         * The transcript is split into work segments, so that multiple people can work on it at the same time.
         * It is converted into a format required by the frontend AddTag component.
         * It is marked as ready for tagging.
         */

        readonly AppSettings config;
        ////readonly IDBOperations dBOperations;
        readonly ILogger<WF2_Process> logger;

        public WF4_Tag(
            IOptions<AppSettings> _config,
            ////IDBOperations _dBOperations,
            ILogger<WF2_Process> _logger
           )
        {
            logger = _logger;
            config = _config.Value;
            ////dBOperations = _dBOperations;
        }
        public void Run()
        {

            // Do we need manager approval?
            bool? approved = true;
            if (!config.RequireManagerApproval) approved = null;

            ////List<Meeting> meetings = dBOperations.FindMeetings(SourceType.Transcript, WorkStatus.Processed, approved);
            List<Meeting> meetings = new List<Meeting>();   // TODO - CA

            foreach (Meeting meeting in meetings)
            {
                StartTagging(meeting);
            }

            ////meetings = dBOperations.FindMeetings(SourceType.Recording, WorkStatus.Tagging, null);
            meetings = new List<Meeting>();   // TODO - CA
            foreach (Meeting meeting in meetings)
            {
                CheckIfTaggingCompleted(meeting);
            }


        }

        public void DoWork(Meeting meeting)
        {
            ////string workfolderName = dBOperations.GetWorkFolderName(meeting);
            string workfolderName = "kjkjkjkjkoou9ukj";  // TODO - CA
            string workFolderPath = config.DatafilesPath + workfolderName;

            if (!GMFileAccess.CreateDirectory(workFolderPath))
            {
                // We were not able to create a folder for processing this video.
                // Probably because the folder already exists.
                Console.WriteLine("ProcessTranscriptsFiles.cs - ERROR: could not create work folder");
                return;
            }

            string sourceFilePath = Path.Combine(config.DatafilesPath, "RECEIVED", meeting.SourceFilename);
            if (!File.Exists(sourceFilePath))
            {
                logger.LogError("Source file does not exist: ${sourceFilePath}");
                return;
            }

            string destFilePath = Path.Combine(config.DatafilesPath, "PROCESSING", meeting.SourceFilename);
            if (File.Exists(destFilePath))
            {
                logger.LogError("Destination file already exists: ${destFilePath}");
            }
            else
            {
                File.Move(sourceFilePath, destFilePath);
            }


            //transcriptProcess.Process(destFilePath, workFolderPath, meeting.Language);
        }


private void StartTagging(Meeting meeting)
{
    //string fixasrText = "";

    //// TODO - Check each part of the transcribed meeting.
    //// Each should contain a xxxxx-DONE.json.
    //// Append them all together into fixasrText.

    //bool b = true;
    //if (b) return;

    //FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(fixasrText);
    //FormatConversions formatConversions = new FormatConversions();
    //AddtagsView addtags = formatConversions.ConvertFixasrToAddtags(fixasr);

    //addtagsRepository.Put(addtags, meeting.Id);

}

private void CheckIfTaggingCompleted(Meeting meeting)
{
    // Get the work folder path
    // TODO - When all of the tagging for a specific transcript is completed, it should:
    //   Change the WorkStatus field in the Meeting Record from "Tagging" to "Tagged"
    //   Send a message to the manager(s) that tagging is completed for a meeting.

}
    }
}



