using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

    // Todo-g #### Change all namespace names from "Models", "Controllers", etc to feature name.
namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class FixasrController : Controller
    {
        private readonly IAuthorizationService _authz;

        public IFixasrRepository fixasr { get; set; }

        public FixasrController(IAuthorizationService authz, IFixasrRepository fixasr)
        //public FixasrController(IAuthorizationService authz)
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
        [Authorize(Policy = "Proofreader")]
        [HttpPost]
        public void Post([FromBody]Fixasr value)
        {
            fixasr.PutByPath(value);
            //fixasr.Put(value, "johnpank", "USA", "ME", "LincolnCounty", "BoothbayHarbor", "Selectmen", "2016-10-11");
        }
    }
}
