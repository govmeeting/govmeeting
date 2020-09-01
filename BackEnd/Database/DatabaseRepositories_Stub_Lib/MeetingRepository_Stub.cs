using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GM.DatabaseModel;
using GM.DatabaseRepositories;

namespace GM.DatabaseRepositories_Stub
{
    public class MeetingRepository_Stub : IMeetingRepository
    {

        public MeetingRepository_Stub()
        {
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
                (element.GovBodyId == meeting.GovBodyId)
            );
            return m.Id;
        }
        public Meeting Get(long govBodyId, DateTime datetime)
        {
            Meeting m = testMeetings.Find(element =>
               (element.GovBodyId == govBodyId) &&
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

        public long Add(Meeting m)
        {
            long id = testMeetings.Count;
            m.Id = id + 1;
            testMeetings.Add(m);
            return m.Id;
        }

        // The LongName is the SourceFilename without the extension + "_" +  meetingId;
        public string GetSourceFilename(long meetingId)
        {
            Meeting m = Get(meetingId);
            return m.SourceFilename;
        }

        public string GetLongName(long meetingId)
        {
            Meeting m = Get(meetingId);
            int i = m.SourceFilename.IndexOf(".") - 1;
            return m.SourceFilename.Substring(0, i) + "_" + m.Id.ToString();
        }

        // These are sample meetings for testing. When WebApp is started, test data for these meetings is
        // copied into the DATAFILES folder. Note that the WorkStatus is set appropriately to match the
        // data that will be in DATAFILES.
        // For example, this means that if the status is "WorkStatus.Tagging", then DATAFILES/PROCESSING
        // will contain work files where the tagging for this meeting is being done.
        // If the status is "WorkStatus.Received", then DATAFILES/RECEIVED will contain the file.

        private readonly List<Meeting> testMeetings = new List<Meeting>
        {
            // The ViewMeeting component in ClientApp asks WebApp for this meeting.
            new Meeting()           // Boothbay Harbor 9/8/2014
            {
                Id = 1,
                Name = "Monthly Regular",
                Date = new DateTime(2014, 9, 8),
                Length = 1810,
                Sections = null,
                GovBodyId = 7,
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
                Sections = null,
                GovBodyId = 5,
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
                Sections = null,
                GovBodyId = 7,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Editing,
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
                Sections = null,
                GovBodyId = 5,
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
                Sections = null,
                GovBodyId = 7,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Received,
                Approved = true
           }

        };
    }
}