using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class FixasrController : Controller
    {
        private readonly IAuthorizationService _authz;

        public IFixasrRepository fixasr { get; set; }

        public FixasrController(IAuthorizationService authz, IFixasrRepository fixasr)
        {
            _authz = authz;
            this.fixasr = fixasr;
        }

        // GET: api/fixasr
        [HttpGet]
        public Fixasr Get()
        {
            Fixasr ret = fixasr.Get("johnpank", "USA", "ME", "LincolnCounty", "BoothbayHarbor", "Selectmen", "2016-10-11");
            return ret;
        }

        // POST api/fixasr
        [HttpPost]
        public void Post([FromBody]Fixasr value)
        {
            fixasr.PutByPath("assets/data/USA_ME_LincolnCounty_BoothbayHarbor_Selectmen/2016-10-11/Step 3 - transcript corrected for errors.json", value);
        }
    }
}
