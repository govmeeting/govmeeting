using GM.Application.DTOs.GovLocations;
using GM.Application.DTOs.Meetings;
using System.Collections.Generic;

namespace GM.Application.DTOs.Govbodies
{
    class GovbodyWithMeetings_Dto
    {
        public GovbodyWithMeetings_Dto()
        {
            this.Meetings = new List<ViewMeeting_Dto>();
            this.Topics = new List<ViewMeetingTopic_Dto>();
            this.ScheduledMeetings = new List<ScheduledMeeting_Dto>();
        }
        public string Name { get; set; }
        public string LongName { get; set; }
        public GovLocation_Dto ParentLocation { get; set; }
        public List<ViewMeeting_Dto> Meetings { get; set; }
        public List<ViewMeetingTopic_Dto> Topics { get; set; }
        public List<ScheduledMeeting_Dto> ScheduledMeetings { get; set; }
    }
}
