using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GM.WebUI.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using GM.WebUI.WebApp.Features.Shared;
using Microsoft.AspNetCore.Hosting;
using GM.Infrastructure.FileDataRepositories.EditMeetings;
using GM.Application.DTOs.Meetings;

namespace GM.WebUI.WebApp.Endpoints.MeetingEdit
{
    [Route("api/[controller]")]
    public class EditMeetingController : Controller
    {
        private readonly IAuthorizationService authz;
        private IEditMeetingRepository EditMeetingRepo { get; set; }

        public EditMeetingController(IAuthorizationService _authz, IEditMeetingRepository _fixasr)
        {
            authz = _authz;
            EditMeetingRepo = _fixasr;
        }

        [HttpGet("{meetingId}/{part}")]        // GET: api/fixasr
        public EditMeetingDto Get(int meetingId, int part)
        {
            string meeting = EditMeetingRepo.Get(meetingId, part);
            EditMeetingDto meetingEditDto = JsonConvert.DeserializeObject<EditMeetingDto>(meeting);
            return meetingEditDto;
        }

        // POST api/fixasr
        // TODO Add next line back when working
        //[Authorize(Policy = "Proofreader")]
        [HttpPost("{meetingId}/{part}")]
        public bool Post([FromBody] EditMeetingDto value, int meetingId, int part)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);
            return EditMeetingRepo.Put(stringValue, meetingId, part);
        }
    }
}
