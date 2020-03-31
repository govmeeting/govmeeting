using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GM.DatabaseModel;

namespace GM.DatabaseRepositories
{
    public class MeetingRepository_Stub : IMeetingRepository
    {
        IGovBodyRepository _govBodyRepository;

        public MeetingRepository_Stub(IGovBodyRepository govBodyRepository)
        {
            _govBodyRepository = govBodyRepository;
        }
 
        public Meeting Get(long meetingId)
        {
            Meeting meeting = GetTestMeeting(meetingId);
            return meeting;
        }

        public long GetId(Meeting meeting)
        {
            Meeting m = testMeetings.Find( element =>
                (element.Date == meeting.Date) &&
                (element.GovernmentBodyId == meeting.GovernmentBodyId)
            );
            return m.Id;
        }
        public Meeting Get(long govBodyId, DateTime datetime)
        {
            Meeting m = testMeetings.Find(element =>
               (element.GovernmentBodyId == govBodyId) &&
               (element.Date == datetime)

            );
            return m;
        }

        public List<Meeting> FindAll(SourceType? sourceType, WorkStatus? workStatus, bool? approved)
        {
            List<Meeting> meetings = testMeetings.FindAll(element =>
               ((sourceType == null) || (element.SourceType == sourceType)) &&
               ((workStatus == null) || (element.WorkStatus == workStatus)) &&
               ((approved == null) || (element.Approved == approved))
            );
            return meetings;
        }


        private Meeting GetTestMeeting(long meetingId)
        {
            Meeting meeting = testMeetings.Single(m => m.Id == meetingId);
            return meeting;
        }

        // These are sample meetings for testing. When WebApp is started, test data for these meetings is
        // copied into the Datafiles folder. Note that the WorkStatus is set appropriately to match the
        // data that will be in Datafiles.
        // For example, this means that if the status is "WorkStatus.Tagging", then Datafiles/PROCESSING
        // will contain work files where the tagging for this meeting is being done.
        // If the status is "WorkStatus.Received", then Datafiles/RECEIVED will contain the file.

        private List<Meeting> testMeetings = new List<Meeting>
        {
            // The ViewMeeting component in ClientApp asks WebApp for this meeting.
            new Meeting()           // Boothbay Harbor 9/8/2014
            {
                Id = 1,
                Name = "Monthly Regular",
                Date = new DateTime(2014, 9, 8),
                Length = 1810,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2014-09-08.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Viewing,
                Approved = false

           },
            // The Addtags component in ClientApp asks WebApp for this meeting.
            new Meeting()           // Philadelphia 9/25/2014
            {
                Id = 2,
                Name = "Monthly Regular",
                Date = new DateTime(2014, 9, 25),
                Length = 3550,
                TopicDiscussions = null,
                GovernmentBodyId = 2,
                SourceFilename = "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2014-09-25.pdf",
                SourceType = SourceType.Transcript,
                WorkStatus = WorkStatus.Tagging,
                Approved = false

           },
            // The Fixasr component in ClientApp asks WebApp for this meeting.
            new Meeting()           // Boothbay Harbor 2/15/2017
            {
                Id = 3,
                Name = "Monthly Regular",
                Date = new DateTime(2017, 2, 15),
                Length = 2109,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Proofreading,
                Approved = false

           },
            // This meeting is a sample PDF transcript file for WorkflowApp to process.
            // Workstatus is set initially to Received, Approved to true.
            // This means the next step, ProcessTranscripts, will start to process it.
            new Meeting()           // Philadelphia 12/07/2017
            {
                Id = 4,
                Name = "Monthly Regular",
                Date = new DateTime(2017, 12, 7),
                // Length = 3466,
                Length = -1,
                TopicDiscussions = null,
                GovernmentBodyId = 2,
                SourceFilename = "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf",
                SourceType = SourceType.Transcript,
                WorkStatus = WorkStatus.Received,
                Approved = true

            },
            // This meeting is a sample MP4 recording for WorkflowApp to process.
            // Workstatus is set initially to Received, Approved to true.
            // This means the next step, ProcessRecordings, will start to process it.
            new Meeting()           // Boothbay Harbor 01/09/2017
            {
                Id = 5,
                Name = "Monthly Regular",
                Date = new DateTime(2017, 1, 09),
                // Length = 192,
                Length = -1,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Received,
                Approved = true
           },
            // This meeting is a sample MP4 recording for WorkflowApp to process.
            // Workstatus is set initially to Received, Approved to false
            // This means it needs to be approved before ProcessRecordings will start to process it.
            new Meeting()           // Boothbay Harbor 01/09/2017
            {
                Id = 5,
                Name = "Monthly Regular",
                Date = new DateTime(2017, 1, 09),
                // Length = 192,
                Length = -1,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Received,
                Approved = false
           }
        };
    }
}

// "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf",
// TODO - This is about 58MB. Github prefers < 50.
//"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4"
//"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4"
