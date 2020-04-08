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
    public class WF_ProcessProofread
    {
        int MEETINGID = 1;      // FOR DEVELOPMENT

        AppSettings config;
        AddtagsRepository addtagsRepository;
        FixasrRepository fixasrRepository;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;

        public WF_ProcessProofread(
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

        // Normally the Run method will search the state of the work on fixing errors in voice recognition text.
        // If it finds that the work is completed for a meeting, it will convert the text into
        // the format needed for the next step in the process: tagging of the transcript.

        // Find all recordings where proofreading is complete and approved.
        public void Run()
        {

            List<Meeting> transcribedMeetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Transcribed, true);
            foreach (Meeting meeting in transcribedMeetings)
            {
                startProofreading(meeting);
            }

            List<Meeting> proofreadingMeetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Proofreading, true);
            foreach (Meeting meeting in proofreadingMeetings)
            {
                CheckIfProofreadingCompleted(meeting);
            }
        }

        public void startProofreading(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            /////// Split the video, audio and transcript into multiple work segments

            string videofileCopy = meetingFolder + "\\" + "01-Video.mp4";
            string outputJsonFile = meetingFolder + "\\" + "04-ToFix.json";

            SplitIntoWorkSegments split = new SplitIntoWorkSegments();
            split.Split(workFolderPath, videofileCopy, outputJsonFile, config.FixasrSegmentSize,
                config.FixasrSegmentOverlap);

            meeting.WorkStatus = WorkStatus.Proofreading;
            meeting.Approved = false;
        }

        public void CheckIfProofreadingCompleted(Meeting meeting)
        {
            // Get the work folder path
            MeetingFolder meetingFolder = new MeetingFolder(govBodyRepository, meeting);
            string workFolderPath = config.DatafilesPath + "\\PROCESSING\\" + meetingFolder.path;

            // TODO - When all of the proofreading for a specific transcript is completed, it should:
            //   Change the WorkStatus field in the Meeting Record from "Proofreading" to "Proofread"
            //   Send a message to the manager(s) that proofreading is completed for a meeting.

        }
    }
}
