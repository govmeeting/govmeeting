using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GM.WebUI.WebApp.Models;
using Microsoft.AspNetCore.Authorization;

using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebUI.WebApp.Endpoints.Meetings
{
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        //// This code needs to be re-written, since we removed DatabaseRepositories_Lib

        //public IMeetingRepository meetings { get; set; }

        //public MeetingController(IMeetingRepository meetings)
        //{
        //    this.meetings = meetings;
        //}

        //[HttpGet("{meetingId}")]
        //public Meeting Get(int meetingId)
        //{
        //    Meeting ret = meetings.Get(meetingId);
        //    return ret;
        //}

        //[HttpGet("{country}/{state}/{county}/{city}/{govEntity?}/{meetingDate?}")]
        //public ViewMeeting Get(string country, string state, string county, string city, string govEntity = "Selectmen", string language = "en", string meetingDate = null)
        //{
        //    return meetings.Get(country, state, county, city, govEntity, language, meetingDate);
        //}

        //// POST api/meeting
        //[HttpPost]
        //[Authorize("PhillyEditor")]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/meeting/5
        //[Authorize("PhillyEditor")]
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
            
        //}

        //// DELETE api/meeting/5
        //[Authorize("PhillyEditor")]
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
