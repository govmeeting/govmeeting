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
    public class TranscriptController : Controller
    {
        // JP: ### Conversion to ASP.NET Core ###
        // JP: FromServices attribute is no longer valid on a property. I moved this DI service to constructor
        // [FromServices]
        public ITranscriptRepository transcripts { get; set; }

        public TranscriptController(ITranscriptRepository transcripts)
        {
            this.transcripts = transcripts;
        }

        // GET: api/transcript
        [HttpGet]
        public Transcript Get()
        {
            //return transcripts.GetByPath("assets/BoothbayHarbor_Selectmen_2014-09-08.json");

            Transcript ret = transcripts.Get("johnpank", "USA", "ME", "LincolnCounty", "BoothbayHarbor", "Selectmen", "2016-10-11");
            return ret;
        }




        [HttpGet("{city}/{govEntity?}/{meetingDate?}")]
        public Transcript Get(string city, string govEntity = null, string meetingDate = null)
        {
            return transcripts.Get(city, govEntity, meetingDate);
        }

        // POST api/transcript
        [HttpPost]
        [Authorize("PhillyEditor")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/transcript/5
        [Authorize("PhillyEditor")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/transcript/5
        [Authorize("PhillyEditor")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
