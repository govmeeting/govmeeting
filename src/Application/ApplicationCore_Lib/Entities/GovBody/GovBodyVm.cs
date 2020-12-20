using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.Govbodies
{
        public class GovbodyVm
        {
            public GovbodyVm()
            {
                this.Meetings = new List<MeetingVm>();
                this.Topics = new List<TopicVm>();
                this.ScheduledMeetings = new List<ScheduledMeetingVm>();
            }
            public string Name { get; set; }
            public string LongName { get; set; }
            public GovLocation ParentLocation { get; set; }
            public List<MeetingVm> Meetings { get; set; }
            public List<TopicVm> Topics { get; set; }
            public List<ScheduledMeetingVm> ScheduledMeetings { get; set; }
        }

}
