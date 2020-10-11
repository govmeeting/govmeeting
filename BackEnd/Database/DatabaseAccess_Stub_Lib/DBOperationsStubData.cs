using GM.DatabaseAccess;
using GM.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseAccess_Stub
{
    public partial class DBOperationsStub : IDBOperations
    {
        // /////////////////// GovBody /////////////////////////////

        private static GovBody CreateGB()
        {
            GovBody gb = new GovBody();
            gb.ScheduledMeetings.Add(
                new ScheduledMeeting()
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-2)
                });
            return gb;
        }

        public List<GovBody> GovBodiesStubData = new List<GovBody>
        {
            new GovBody()
            {
                Id = 1,
                Name = "Board of Selectmen",
                GovLocationId = 7   // Boothbay Harbor
            },
            CreateGB()
            //new GovBody()
            //{
            //    Id = 1,
            //    Name = "City Council",
            //    GovLocationId = 5,   // Philadelphia
            //    ScheduledMeetings = new List<ScheduledMeeting>()
            //    {
            //        new ScheduledMeeting()
            //        {
            //            Id = 1,
            //            Date = DateTime.Now.AddDays(-2)
            //        }
            //    }
            //}
        };

        // /////////////////// GovLocation /////////////////////////////



        private List<GovLocation> GovLocationsStubData = new List<GovLocation>
        {
            new GovLocation("en")
            {
                Id = 1,
                Name = "United States of America",
                Code = "USA",
                GovLocationId = 0
            },
            new GovLocation()
            {
                Id = 2,
                Name = "Pennsylvania",
                Code = "PA",
                GovLocationId = 1
            },
            new GovLocation("en")
            {
                Id = 3,
                Name = "New Jersey",
                Code = "NJ",
                GovLocationId = 1
            },
            new GovLocation("en")
            {
                Id = 4,
                Name = "Maine",
                Code = "ME",
                GovLocationId = 1
            },
            new GovLocation("en")
            {
                Id = 5,
                Name = "Philadelphia",
                Code = "",
                GovLocationId = 2
            },
            new GovLocation("en")
            {
                Id = 6,
                Name = "Little Falls",
                Code = "",
                GovLocationId = 3
            },
            new GovLocation("en")
            {
                Id = 7,
                Name = "Boothbay Harbor",
                Code = "",
                GovLocationId = 4
            },
            new GovLocation("en")
            {
                Id = 8,
                Name = "Australia",
                Code = "AUS",
                GovLocationId = 0
            },
            new GovLocation("en")
            {
                Id = 9,
                Name = "Victoria",
                Code = "Vic",
                GovLocationId = 8
            },
            new GovLocation("en")
            {
                Id = 10,
                Name = "Melbourne",
                Code = "",
                GovLocationId = 9
            }
        };


        // /////////////////// Meeting /////////////////////////////

        private readonly List<Meeting> MeetingsStubData = new List<Meeting>
        {
            // The ViewMeeting component in ClientApp asks WebApp for this meeting.
            new Meeting()           // Boothbay Harbor 9/8/2014
            {
                Id = 1,
                Name = "Monthly Regular",
                Date = new DateTime(2014, 9, 8),
                Length = 1810,
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
                GovBodyId = 7,
                SourceFilename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.mp4",
                SourceType = SourceType.Recording,
                WorkStatus = WorkStatus.Received,
                Approved = true
           }
        };

    }
}
