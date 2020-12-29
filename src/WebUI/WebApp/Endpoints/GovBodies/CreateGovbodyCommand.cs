using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.DTOs.Govbodies;
using GM.Application.DTOs.Meetings;
using GM.Application.DTOs.Topics;
using MediatR;
using System.Collections.Generic;

//namespace GM.Application.DTOs.Govbodies
namespace GM.WebUI.WebApp.Endpoints.Govbodies
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
