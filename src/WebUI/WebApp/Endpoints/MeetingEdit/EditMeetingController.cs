using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GM.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using GM.WebApp.Features.Shared;
using Microsoft.AspNetCore.Hosting;
using GM.FileDataRepositories;
using GM.ViewModels;


namespace WebApp.Endpoints.MeetingEdit
{
    [Route("api/[controller]")]
    public class EditMeetingController : Controller
    {
        private readonly IAuthorizationService authz;
        private IEditMeetingRepository editMeetingRepo { get; set; }

        public EditMeetingController(IAuthorizationService _authz, IEditMeetingRepository _fixasr)
        {
            authz = _authz;
            editMeetingRepo = _fixasr;
        }

        [HttpGet("{meetingId}/{part}")]        // GET: api/fixasr
        public MeetingEditDto Get(int meetingId, int part)
        {
            string meeting = editMeetingRepo.Get(meetingId, part);
            MeetingEditDto meetingEditDto = JsonConvert.DeserializeObject<MeetingEditDto>(meeting);
            return meetingEditDto;
        }

        // POST api/fixasr
        // TODO Add next line back when working
        //[Authorize(Policy = "Proofreader")]
        [HttpPost("{meetingId}/{part}")]
        public bool Post([FromBody] MeetingEditDto value, int meetingId, int part)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);
            return editMeetingRepo.Put(stringValue, meetingId, part);
        }
    }
}
