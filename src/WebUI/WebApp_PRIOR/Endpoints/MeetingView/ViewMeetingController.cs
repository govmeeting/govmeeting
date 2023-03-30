using GM.Application.DTOs.Meetings;
using GM.Infrastructure.FileDataRepositories.ViewMeetings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebUI.WebApp.Endpoints.Viewtranscripts
{
    [Route("api/[controller]")]
    public class ViewMeetingController : Controller
    {
        public IViewMeetingRepository Meetings { get; set; }

        public ViewMeetingController(IViewMeetingRepository meetings)
        {
            this.Meetings = meetings;
        }

        [HttpGet("{meetingId}")]
        public ViewMeeting_Dto Get(int meetingId)
        {
            string transcript = Meetings.Get(meetingId);
            ViewMeeting_Dto viewMeeting = JsonConvert.DeserializeObject<ViewMeeting_Dto>(transcript);
            return viewMeeting;
        }

        //[HttpPut("{meetingId}")]
        //public bool Put(int meetingId, ViewMeeting_Dto meetingDto)
        //{
        //    string stringValue = JsonConvert.SerializeObject(meetingDto, Formatting.Indented);
        //    bool result = Meetings.Put(meetingId, stringValue);
        //    return result;
        //}

        [HttpPut]
        public bool Put(ViewMeeting_Dto meetingDto)
        {
            int meetingId = meetingDto.MeetingId;
            string stringValue = JsonConvert.SerializeObject(meetingDto, Formatting.Indented);
            bool result = Meetings.Put(meetingId, stringValue);
            return result;
        }
    }
}
