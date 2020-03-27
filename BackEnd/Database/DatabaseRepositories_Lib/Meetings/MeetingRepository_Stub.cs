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

        private Meeting GetTestMeeting(long meetingId)
        {
            Meeting meeting = testMeetings.Single(m => m.Id == meetingId);
            return meeting;
        }

        private List<Meeting> testMeetings = new List<Meeting>
        {
            new Meeting()           // Boothbay Harbor 9/8/2014
            {
                Id = 1,
                Name = "Monthly Regular",
                Date = new DateTime(2014,9, 8),
                Length = 1810,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                WorkStatus = WorkStatus.Viewing
           },
            new Meeting()           // Philadelphia 9/25/2014
            {
                Id = 2,
                Name = "Monthly Regular",
                Date = new DateTime(2014,9, 25),
                Length = 3550,
                TopicDiscussions = null,
                GovernmentBodyId = 2,
                WorkStatus = WorkStatus.Tagging
           },
            new Meeting()           // Boothbay Harbor 2/15/2017
            {
                Id = 3,
                Name = "Monthly Regular",
                Date = new DateTime(2017,2, 15),
                Length = 2109,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                WorkStatus = WorkStatus.FixingAsr
           },
            new Meeting()           // Philadelphia 3/15/2016
            {
                Id = 4,
                Name = "Monthly Regular",
                Date = new DateTime(2017,2, 15),
                Length = 3466,
                TopicDiscussions = null,
                GovernmentBodyId = 2,
                WorkStatus = WorkStatus.Retrieving
            },
            new Meeting()           // Boothbay Harbor 2/15/2017
            {
                Id = 5,
                Name = "Monthly Regular",
                Date = new DateTime(2017,1, 09),
                Length = 192,
                TopicDiscussions = null,
                GovernmentBodyId = 1,
                WorkStatus = WorkStatus.Retrieving
           }
        };
    }
}
