using System.Collections.Generic;
using GM.Application.DTOs.GovLocations;
using GM.Application.DTOs.Meetings;


namespace GM.Application.DTOs.Govbodies
{
        public class GovbodyDto
        {
            public GovbodyDto()
            {
                this.Meetings = new List<ViewMeetingDto>();
                this.Topics = new List<ViewMeetingTopicDto>();
                this.ScheduledMeetings = new List<ScheduledMeetingDto>();
            }
            public string Name { get; set; }
            public string LongName { get; set; }
            public GovLocationDto ParentLocation { get; set; }
            public List<ViewMeetingDto> Meetings { get; set; }
            public List<ViewMeetingTopicDto> Topics { get; set; }
            public List<ScheduledMeetingDto> ScheduledMeetings { get; set; }
        }

}
