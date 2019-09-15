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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

// TODO #### Change all namespace names from "Models", "Controllers", etc to feature name.
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
        [Authorize(Policy = "Proofreader")]
        [HttpPost("{meetingId}/{part}")]
        public void Post([FromBody]FixasrView value, int meetingId, int part)
        {
            bool success = fixasr.Put(value, meetingId, part);
        }
    }
}
