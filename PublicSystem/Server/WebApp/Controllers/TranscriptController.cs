using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapp.Controllers
{
    [Route("api/[controller]")]
    public class TranscriptController : Controller
    {
        [FromServices]
        public ITranscriptRepository transcripts { get; set; }

        // GET: api/transcript
        [HttpGet]
        public Transcript Get()
        {
            return transcripts.GetByPath("assets/BBH-2014-09-08 - Copy.json");
        }

        /*
        // GET api/transcript/5
        [HttpGet("{id}")]
        public Transcript Get(int id)
        {
            //return "value";
            switch (id) {
                case 1: 
                    return transcripts.GetByPath("assets/BBH-2014-09-08.json");
                case 2:
                    return transcripts.GetByPath("assets/Philadelphia_CityCouncil_03_17_2016.json");
            }
        }
        */

        // POST api/transcript
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/transcript/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/transcript/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
