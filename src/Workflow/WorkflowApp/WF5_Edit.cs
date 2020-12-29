using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using GM.Application.Configuration;
using Newtonsoft.Json;
using GM.Infrastructure.FileDataRepositories;
using GM.Application.EditTranscript;

using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;


namespace GM.WorkflowApp
{

    public class WF5_Edit
    {
        readonly AppSettings config;
        ////readonly IDBOperations dBOperations;

        public WF5_Edit(
            IOptions<AppSettings> _config
            ////IDBOperations _dBOperations
            )
        {
            config = _config.Value;
            ////dBOperations = _dBOperations;
        }

        public void Run()
        {
            ////List<Meeting> transcribedMeetings = dBOperations.FindMeetings(SourceType.Recording, WorkStatus.Transcribed, true);
            List<Meeting> transcribedMeetings = new List<Meeting>();   // TODO - CA
            foreach (Meeting meeting in transcribedMeetings)
            {
                StartEditing(meeting);
            }

            ////List<Meeting> proofreadingMeetings = dBOperations.FindMeetings(SourceType.Recording, WorkStatus.Editing, null);
            List<Meeting> proofreadingMeetings = new List<Meeting>();   // TODO - CA
            foreach (Meeting meeting in proofreadingMeetings)
            {
                CheckIfEditingCompleted(meeting);
            }

        }

        private void StartEditing(Meeting meeting)
        {
            ///// Reformat the JSON transcript to match what the fixasr routine will use.

            //ModifyTranscriptJson_1 convert = new ModifyTranscriptJson_1();
            //outputJsonFile = Path.Combine(meetingFolder, "04-ToFix.json");
            //FixasrView fixasr = convert.Modify(transcript);
            //stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            //File.WriteAllText(outputJsonFile, stringValue);



            //WorkSegments split = new WorkSegments();
            //split.Split(meetingFolder, videofileCopy, outputJsonFile, config.FixasrSegmentSize,
            //    config.FixasrSegmentOverlap);


            string fixasrText = "";

            // TODO - Check each part of the transcribed meeting.
            // Each should contain a xxxxx-DONE.json.
            // Append them all together into fixasrText.

            bool b = true;
            if (b) return;

            //FixasrViewModel fixasr = JsonConvert.DeserializeObject<FixasrViewModel>(fixasrText);
            //FormatConversions formatConversions = new FormatConversions();
            //AddtagsViewModel addtags = formatConversions.ConvertFixasrToAddtags(fixasr);

            //addtagsRepository.Put(addtags, meeting.Id);

        }

        private void CheckIfEditingCompleted(Meeting meeting)
        {
            ////string workfolderName = dBOperations.GetWorkFolderName(meeting);
            string workfolderName = "kjkjkjkjkoou9ukj";  // TODO - CA
            string workFolderPath = config.DatafilesPath + workfolderName;

            // TODO - When all of the tagging for a specific transcript is completed, it should:
            //   Change the WorkStatus field in the Meeting Record from "Tagging" to "Tagged"
            //   Send a message to the manager(s) that tagging is completed for a meeting.

        }

        //private void CheckIfEditingCompleted(Meeting meeting)
        //{
        //    string workfolderPath = GetWorkfolderPath(meeting);
        //    if (workSegments.CheckIfFinished(workfolderPath))
        //    {
        //        workSegments.Combine(workfolderPath, "ToView.json");
        //    }

        //    meeting.WorkStatus = WorkStatus.Edited;

        //    // Edited transcript needs to be approved before it is available to view.
        //    meeting.Approved = false;
        //}


    }
}
