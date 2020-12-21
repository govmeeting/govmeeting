using GM.ApplicationCore.Entities.Meetings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using GM.ApplicationCore.Entities.Topics;
using GM.ApplicationCore.Entities.GovLocations;
using GM.ApplicationCore.Entities.MeetingsDto;
using GM.ApplicationCore.Entities.TopicsDto;

namespace GM.ApplicationCore.Entities.GovbodiesDto
{
    public class CreateGovbodyCommand : IRequest<int?>
    {
        public CreateGovbodyCommand()
        {
            this.Meetings = new List<ListMeetingDto>();
            this.Topics = new List<TopicDto>();
            this.ScheduledMeetings = new List<ScheduledMeetingDto>();
        }
        public string Name { get; set; }
        public string LongName { get; set; }
        public GovLocation ParentLocation { get; set; }
        public List<ListMeetingDto> Meetings { get; set; }
        public List<TopicDto> Topics { get; set; }
        public List<ScheduledMeetingDto> ScheduledMeetings { get; set; }
    }
}
