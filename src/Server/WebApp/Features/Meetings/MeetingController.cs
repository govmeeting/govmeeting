using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapp.Controllers
{
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        // JP: ### Conversion to ASP.NET Core ###
        // JP: FromServices attribute is no longer valid on a property. I moved this DI service to constructor
        // [FromServices]
        public IMeetingRepository meetings { get; set; }

        public MeetingController(IMeetingRepository meetings)
        {
            this.meetings = meetings;
        }

        // default when no parameters passed. Used for testing.
        [HttpGet]
        public Meeting Get()
        {
            //return meetings.GetByPath("assets/BoothbayHarbor_Selectmen_2014-09-08.json");

            Meeting ret = meetings.Get("USA", "ME", "LincolnCounty", "BoothbayHarbor", "Selectmen", "2014-09-08");
            return ret;
        }

        [HttpGet("{country}/{state}/{county}/{city}/{govEntity?}/{meetingDate?}")]
        public Meeting Get(string country, string state, string county, string city, string govEntity = null, string meetingDate = null)
        {
            return meetings.Get(country, state, county, city, govEntity, meetingDate);
        }

        // POST api/meeting
        [HttpPost]
        [Authorize("PhillyEditor")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/meeting/5
        [Authorize("PhillyEditor")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/meeting/5
        [Authorize("PhillyEditor")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
