using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GM.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using GM.FileDataRepositories;
using GM.ViewModels;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebApp.Features.Viewtranscripts
{
    [Route("api/[controller]")]
    public class ViewMeetingController : Controller
    {
        public IViewMeetingRepository meetings { get; set; }

        public ViewMeetingController(IViewMeetingRepository meetings)
        {
            this.meetings = meetings;
        }

        [HttpGet("{meetingId}")]
        public MeetingViewDto Get(int meetingId)
        {
            string transcript = meetings.Get(meetingId);
            MeetingViewDto viewMeeting = JsonConvert.DeserializeObject<MeetingViewDto>(transcript);
            return viewMeeting;
        }

        [HttpPut("{meetingId}")]
        public bool Put(int meetingId, MeetingViewDto meetingDto)
        {
            string stringValue = JsonConvert.SerializeObject(meetingDto, Formatting.Indented);
            bool result = meetings.Put(meetingId, stringValue);
            return result;
        }
    }
}
