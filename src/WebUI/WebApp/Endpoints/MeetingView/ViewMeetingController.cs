﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GM.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using GM.FileDataRepositories;
using Newtonsoft.Json;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.MeetingsDto;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebApp.Features.Viewtranscripts
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
        public ViewMeetingDto Get(int meetingId)
        {
            string transcript = Meetings.Get(meetingId);
            ViewMeetingDto viewMeeting = JsonConvert.DeserializeObject<ViewMeetingDto>(transcript);
            return viewMeeting;
        }

        [HttpPut("{meetingId}")]
        public bool Put(int meetingId, ViewMeetingDto meetingDto)
        {
            string stringValue = JsonConvert.SerializeObject(meetingDto, Formatting.Indented);
            bool result = Meetings.Put(meetingId, stringValue);
            return result;
        }
    }
}
