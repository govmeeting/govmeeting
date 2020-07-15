using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using GM.WebApp.Features.Shared;
using Microsoft.AspNetCore.Hosting;
using GM.FileDataRepositories;
using GM.ViewModels;

// TODO There is probably an easier, standard, way to disable authentication in Asp.Net Core.
// $define NOAUTH       // uncomment this to disable auth. You can also define NOAUTH in project properties.

namespace GM.WebApp.Features.Fixasr
{
    [Route("api/[controller]")]
    public class FixasrController : Controller
    {
        //private readonly IAuthorizationService authz;
        //private readonly IWebHostEnvironment env;
        private IFixasrRepository Fixasr { get; set; }

        public FixasrController(IFixasrRepository _fixasr)
        {
            Fixasr = _fixasr;
        }
        //public FixasrController(IAuthorizationService Authz, IFixasrRepository Fixasr, IWebHostEnvironment Env)
        //{
        //}

        [HttpGet("{meetingId}/{part}")]        // GET: api/fixasr
        public FixasrView Get(int meetingId, int part)
        {
            FixasrView ret = Fixasr.Get(meetingId, part);
            return ret;
        }

        // POST api/fixasr
        // TODO Add next line back when working
#if NOAUTH
#else
        [Authorize(Policy = "Proofreader")]
#endif
        [HttpPost("{meetingId}/{part}")]
        public bool Post([FromBody]FixasrView value, int meetingId, int part)
        {
            return Fixasr.Put(value, meetingId, part);
        }
    }
}
