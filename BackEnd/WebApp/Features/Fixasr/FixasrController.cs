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

// $define NOAUTH       // uncomment this to disable auth. You can also define NOAUTH in project properties.

namespace GM.WebApp.Features.Fixasr
{
    [Route("api/[controller]")]
    public class FixasrController : Controller
    {
        private readonly IAuthorizationService authz;
        private readonly IHostingEnvironment env;
        private IFixasrRepository fixasr { get; set; }

        public FixasrController(IAuthorizationService _authz, IFixasrRepository _fixasr, IHostingEnvironment _env)
        {
            authz = _authz;
            fixasr = _fixasr;
            env = _env;
        }

        [HttpGet("{meetingId}/{part}")]        // GET: api/fixasr
        public FixasrView Get(int meetingId, int part)
        {
            FixasrView ret = fixasr.Get(meetingId, part);
            return ret;
        }

        // POST api/fixasr
        // TODO Add next line back when working
#if NOAUTH
        [Authorize(Policy = "Proofreader")]
#endif
        [HttpPost("{meetingId}/{part}")]
        public bool Post([FromBody]FixasrView value, int meetingId, int part)
        {
            return fixasr.Put(value, meetingId, part);
        }
    }
}
