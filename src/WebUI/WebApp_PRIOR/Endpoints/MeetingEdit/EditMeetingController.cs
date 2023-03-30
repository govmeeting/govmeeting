using GM.Application.DTOs.Meetings;
using GM.Infrastructure.FileDataRepositories.EditMeetings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GM.WebUI.WebApp.Endpoints.MeetingEdit
{
    [Route("api/[controller]")]
    public class EditMeetingController : Controller
    {
        private readonly IAuthorizationService authz;
        private IEditMeetingRepository EditMeetingRepo { get; set; }

        public EditMeetingController(IAuthorizationService _authz, IEditMeetingRepository _editMeetingRepo)
        {
            authz = _authz;
            EditMeetingRepo = _editMeetingRepo;
        }

        [HttpGet("{meetingId}/{part}")]        // GET: api/EditMeeting
        public EditMeeting_Dto Get(int meetingId, int part)
        {
            string meeting = EditMeetingRepo.Get(meetingId, part);
            EditMeeting_Dto meetingEditDto = JsonConvert.DeserializeObject<EditMeeting_Dto>(meeting);
            return meetingEditDto;
        }

        // POST api/fixasr
        // TODO Add next line back when working
        //[Authorize(Policy = "Proofreader")]
        [HttpPost("{meetingId}/{part}")]
        public bool Post([FromBody] EditMeeting_Dto value, int meetingId, int part)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);
            return EditMeetingRepo.Put(stringValue, meetingId, part);
        }
    }
}
