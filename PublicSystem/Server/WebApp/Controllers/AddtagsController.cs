using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApp.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AddtagsController : Controller
    {
        private readonly IAuthorizationService _authz;

        public AddtagsController(IAuthorizationService authz)
        {
            _authz = authz;
        }

        /*
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        */

        [FromServices]
        public IAddtagsRepository addtags { get; set; }

        // GET: api/addtags
        [HttpGet]
        public Addtags Get()
        // public string Get()
        {
            return addtags.Get("johnpank", "Philadelphia", "CityCouncil", "2016-03-17");
        }

        /*
        // GET api/addtags/1
        [HttpGet("{id}")]
        public Addtags Get(int id)
        {
            //return "value";
            switch (id)
            {
                case 1:
                default:
                    return addtags.Get("johnpank", "Philadelphia", "CityCouncil", "2016-03-17");
                case 2:
                    return addtags.Get("johnpank", "Philadelphia", "CityCouncil", "2014-09-25");
            }
        }
        */

            /*
        // GET: api/addtags/user/ciry/entity/meetingdate
        //[HttpGet("{city}/{goventity}/{meetingdate}")]
        //public Addtags Get(string city, string goventity,  string meetingdate)
        [HttpGet("{city}")]
        public Addtags Get(string city)
        // public string Get()
        {
            //return addtags.GetByPath("assets/Philadelphia_CityCouncil_03_17_2016 - Copy.json");
            //return addtags.GetStringByPath("assets/Philadelphia_CityCouncil_03_17_2016.json");
            //return addtags.GetByPath("assets/Philadelphia_CityCouncil_03_17_2016.json");
            //return addtags.Get("johnpank", "Philadelphia", "CityCouncil", "2016_03_17");
            //return addtags.Get("johnpank", city, goventity, meetingdate);
            return addtags.Get("johnpank", city, "CityCouncil", "2016-03-17");
        }
        */

        /*
        [HttpGet("{city}/{goventity}")]
        public Addtags Get(string city, string goventity)
        {
            return addtags.Get("johnpank", city, goventity, "2016-03-17");
        }
        */

        [HttpGet("{city}/{govEntity?}/{meetingDate?}")]
        public Addtags Get(string city, string govEntity = null, string meetingDate = null)
        {
            return addtags.Get("johnpank", city, govEntity, meetingDate);
        }


        // POST api/addtags
        [HttpPost]
        //public void Post([FromBody]string value)
        public void Post([FromBody]Addtags value)
        {
                addtags.PutByPath("assets/Philadelphia_CityCouncil_03_17_2016 - Backup.json", value);
        }

        /* This is code in progress. I am trying to add authorization to this method.
        public async Task<IActionResult> Post([FromBody]Addtags value)
        {
            if (await _authz.AuthorizeAsync(User, "SalesSenior"))
            {
                addtags.PutByPath("assets/Philadelphia_CityCouncil_03_17_2016 - Backup.json", value);
                // What do I return?
            } else
            {
               // Is this correct?
                return new ChallengeResult();
            }
        }
        */

    }
}
