using System;
using System.Collections.Generic;
using System.Text;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Topics;
using GM.ApplicationCore.Entities.GovLocations;
using GM.ApplicationCore.Entities.MeetingsDto;
using GM.ApplicationCore.Entities.GovLocationsDto;

namespace GM.ApplicationCore.Entities.GovbodiesDto
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
