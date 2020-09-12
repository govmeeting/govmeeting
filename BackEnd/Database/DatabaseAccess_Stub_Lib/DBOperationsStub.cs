using System;
using System.Collections.Generic;
using System.Linq;
using GM.DatabaseAccess;
using GM.DatabaseModel;

namespace GM.DatabaseAccess_Stub
{
    public partial class DBOperationsStub : IDBOperations
    {
        public void WriteChanges()
        {

        }
        public Meeting GetMeeting(long meetingId)
        {
            Meeting meeting = MeetingsStubData.Single(m => m.Id == meetingId);
            return meeting;
        }
        public List<Meeting> GetMeetings(int govBodyId)
        {
            // TODO - Implement
            return new List<Meeting>();
        }
        public GovBody GetGovBody(long govBodyId)
        {
            GovBody govBody = GovBodiesStubData.Single(m => m.Id == govBodyId);
            return govBody;
        }
        public List<GovBody> GetGovBodies()
        {
            // TODO - Implement
            return new List<GovBody>();
        }
        public GovLocation GetGovLocation(long govLocationId)
        {
            GovLocation govBody = GovLocationsStubData.Single(m => m.Id == govLocationId);
            return govBody;
        }
        public List<GovLocation> GetGovLocation()
        {
            // TODO - Implement
            return new List<GovLocation>();
        }
        public List<Category> GetCategories()
        {
            // TODO - Implement
            return new List<Category>();
        }
        public List<Topic> GetExistingTopics(long govBodyId)
        {
            // TODO - Implement
            return new List<Topic>();
        }
        public List<TopicDiscussion> GetTopicDiscussions(int meetingId)
        {
            // TODO - Implement
            return new List<TopicDiscussion>();
        }
        public List<Talk> GetTalks(int topicDiscussionId)
        {
            // TODO - Implement
            return new List<Talk>();
        }

        // ###########   The folowing are not in IDBOperations   ################

        // Add assumes that the Meeting's GovBodyId property is set correctly
        public long Add(Meeting m)
        {
            long id = MeetingsStubData.Count;
            m.Id = id + 1;
            MeetingsStubData.Add(m);
            return m.Id;
        }

        public long Add(GovLocation govLocation)
        {
            long id = GovLocationsStubData.Count + 1;
            govLocation.Id = id;
            GovLocationsStubData.Add(govLocation);
            return id;
        }

        public long Add(GovBody govBody)
        {
            long id = GovBodiesStubData.Count + 1;
            govBody.Id = id;
            GovBodiesStubData.Add(govBody);
            return id;
        }

        public List<Meeting> FindMeetings(SourceType? sourceType, WorkStatus? workStatus, bool? approved)
        {
            List<Meeting> meetings = MeetingsStubData.FindAll(element =>
               ((sourceType == null) || (element.SourceType == sourceType)) &&
               ((workStatus == null) || (element.WorkStatus == workStatus)) &&
               ((approved == null) || (element.Approved == approved))
            );
            return meetings;
        }

        public List<GovBody> FindGovBodiesWithScheduledMeetings()
        {
            // TODO - implement
            return new List<GovBody>();
        }

        public string GetWorkFolderName(Meeting meeting)
        {
            GovBody govbody = GetGovBody(meeting.GovBodyId);
            return govbody.LongName + "_" + meeting.Date;
        }


        //// /////////////////// STUB DATA ///////////////////////////////////

        //// /////////////////// GovBody /////////////////////////////

        //private List<GovBody> GovBodiesStubData = new List<GovBody>
        //{
        //    new GovBody()
        //    {
        //        Id = 1,
        //        Name = "Board of Selectmen",
        //        GovLocationId = 7   // Boothbay Harbor
        //    },
        //    new GovBody()
        //    {
        //        Id = 1,
        //        Name = "City Council",
        //        GovLocationId = 5,   // Philadelphia
        //        ScheduledMeetings = new List<ScheduledMeeting>()
        //        {
        //            new ScheduledMeeting()
        //            {
        //                Id = 1,
        //                Date = DateTime.Now.AddDays(-2)
        //            }
        //        }
        //    }
        //};

        //// /////////////////// GovLocation /////////////////////////////

        //private List<GovLocation> GovLocationsStubData = new List<GovLocation>
        //{
        //    new GovLocation()
        //    {
        //        Id = 1,
        //        Name = "United States of America",
        //        Code = "USA",
        //        GovLocationId = 0,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 2,
        //        Name = "Pennsylvania",
        //        Code = "PA",
        //        GovLocationId = 1,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 3,
        //        Name = "New Jersey",
        //        Code = "NJ",
        //        GovLocationId = 1,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 4,
        //        Name = "Maine",
        //        Code = "ME",
        //        GovLocationId = 1,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 5,
        //        Name = "Philadelphia",
        //        Code = "",
        //        GovLocationId = 2,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 6,
        //        Name = "Little Falls",
        //        Code = "",
        //        GovLocationId = 3,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 7,
        //        Name = "Boothbay Harbor",
        //        Code = "",
        //        GovLocationId = 4,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 8,
        //        Name = "Australia",
        //        Code = "AUS",
        //        GovLocationId = 0,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 9,
        //        Name = "Victoria",
        //        Code = "Vic",
        //        GovLocationId = 8,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    },
        //    new GovLocation()
        //    {
        //        Id = 10,
        //        Name = "Melbourne",
        //        Code = "",
        //        GovLocationId = 9,
        //        Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
        //    }
        //};


        //// /////////////////// Meeting /////////////////////////////

        //private readonly List<Meeting> MeetingsStubData = new List<Meeting>
        //{
        //    // The ViewMeeting component in ClientApp asks WebApp for this meeting.
        //    new Meeting()           // Boothbay Harbor 9/8/2014
        //    {
        //        Id = 1,
        //        Name = "Monthly Regular",
        //        Date = new DateTime(2014, 9, 8),
        //        Length = 1810,
        //        Sections = null,
        //        GovBodyId = 7,
        //        SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2014-09-08.mp4",
        //        SourceType = SourceType.Recording,
        //        WorkStatus = WorkStatus.Viewing,
        //        Approved = false

        //   },
        //    // The Addtags component in ClientApp asks WebApp for this meeting.
        //    new Meeting()           // Philadelphia 9/25/2014
        //    {
        //        Id = 2,
        //        Name = "Monthly Regular",
        //        Date = new DateTime(2014, 9, 25),
        //        Length = 3550,
        //        Sections = null,
        //        GovBodyId = 5,
        //        SourceFilename = "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2014-09-25.pdf",
        //        SourceType = SourceType.Transcript,
        //        WorkStatus = WorkStatus.Tagging,
        //        Approved = false

        //   },
        //    // The Fixasr component in ClientApp asks WebApp for this meeting.
        //    new Meeting()           // Boothbay Harbor 2/15/2017
        //    {
        //        Id = 3,
        //        Name = "Monthly Regular",
        //        Date = new DateTime(2017, 2, 15),
        //        Length = 2109,
        //        Sections = null,
        //        GovBodyId = 7,
        //        SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4",
        //        SourceType = SourceType.Recording,
        //        WorkStatus = WorkStatus.Editing,
        //        Approved = false

        //   },
        //    // This meeting is a sample PDF transcript file for WorkflowApp to process.
        //    // Workstatus is set initially to Received, Approved to true.
        //    // This means the next step, ProcessTranscripts, will start to process it.
        //    new Meeting()           // Philadelphia 12/07/2017
        //    {
        //        Id = 4,
        //        Name = "Monthly Regular",
        //        Date = new DateTime(2017, 12, 7),
        //        // Length = 3466,
        //        Length = -1,
        //        Sections = null,
        //        GovBodyId = 5,
        //        SourceFilename = "USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf",
        //        SourceType = SourceType.Transcript,
        //        WorkStatus = WorkStatus.Received,
        //        Approved = true

        //    },
        //    // This meeting is a sample MP4 recording for WorkflowApp to process.
        //    // Workstatus is set initially to Received, Approved to true.
        //    // This means the next step, ProcessRecordings, will start to process it.
        //    new Meeting()           // Boothbay Harbor 01/09/2017
        //    {
        //        Id = 5,
        //        Name = "Monthly Regular",
        //        Date = new DateTime(2017, 1, 09),
        //        // Length = 192,
        //        Length = -1,
        //        Sections = null,
        //        GovBodyId = 7,
        //        SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",
        //        SourceType = SourceType.Recording,
        //        WorkStatus = WorkStatus.Received,
        //        Approved = true
        //   }
        //};
    }
}
