using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using GM.Configuration;
using Newtonsoft.Json;
using GM.FileDataRepositories;
using GM.ViewModels;
using GM.DatabaseRepositories;
using GM.DatabaseModel;
using GM.ProcessRecording;

namespace GM.Workflow
{
    public class WF_ProcessTagged
    {
        AppSettings config;
        AddtagsRepository addtagsRepository;
        FixasrRepository fixasrRepository;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;

        public WF_ProcessTagged(
            IOptions<AppSettings> _config,
            AddtagsRepository _addtagsRepository,
            FixasrRepository _fixasrRepository,
            IGovBodyRepository _govBodyRepository,
            IMeetingRepository _meetingRepository
            )
        {
            config = _config.Value;
            addtagsRepository = _addtagsRepository;
            fixasrRepository = _fixasrRepository;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        public void Run()
        {
            List<Meeting> transcribedMeetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Transcribed, true);
            foreach (Meeting meeting in transcribedMeetings)
            {
                StartTagging(meeting);
            }

            List<Meeting> proofreadingMeetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Proofreading, true);
            foreach (Meeting meeting in proofreadingMeetings)
            {
                CheckIfTaggingCompleted(meeting);
            }

        }

        private void StartTagging(Meeting meeting)
        {
            string fixasrText = "";

            // TODO - Check each part of the transcribed meeting.
            // Each should contain a xxxxx-DONE.json.
            // Append them all together into fixasrText.

            bool b = true;
            if (b) return;

            FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(fixasrText);
            FormatConversions formatConversions = new FormatConversions();
            AddtagsView addtags = formatConversions.ConvertFixasrToAddtags(fixasr);

            addtagsRepository.Put(addtags, meeting.Id);

        }

        private void CheckIfTaggingCompleted(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            // TODO - When all of the tagging for a specific transcript is completed, it should:
            //   Change the WorkStatus field in the Meeting Record from "Tagging" to "Tagged"
            //   Send a message to the manager(s) that tagging is completed for a meeting.

        }
    }
}
