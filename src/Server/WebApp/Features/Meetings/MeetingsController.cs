using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        // JP: ### Conversion to ASP.NET Core ###
        // JP: FromServices attribute is no longer valid on a property. I moved this DI service to constructor
        // [FromServices]
        public IMeetingRepository meetings { get; set; }

        public MeetingsController(IMeetingRepository meetings)
        {
            this.meetings = meetings;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Meeting> Get()
        {
            return meetings.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
