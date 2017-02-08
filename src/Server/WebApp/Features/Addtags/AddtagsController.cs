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
    public class AddtagsController : Controller
    {
        private readonly IAuthorizationService _authz;

        // JP: ### Conversion to ASP.NET Core ###
        // JP: FromServices attribute is no longer valid on a property. I moved this DI service to constructor
        // [FromServices]
        public IAddtagsRepository addtags { get; set; }

        public AddtagsController(IAuthorizationService authz, IAddtagsRepository addtags)
        {
            _authz = authz;
            this.addtags = addtags;
        }

        /*
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        */

        // GET: api/addtags
        [HttpGet]
        public Addtags Get()
        // public string Get()
        {
            Addtags ret = addtags.Get("johnpank", "USA", "PA", "Philadelphia", "CityCouncil", "2016-03-17");
            return ret;
        }

        // POST api/addtags
        [HttpPost]
        //public void Post([FromForm]string value)
        public void Post([FromBody]Addtags value)
        //public void Post(Addtags value)
        {
            addtags.PutByPath("assets/data/USA_PA_Philadelphia_CityCouncil/2016-03-17/Step 3 - Added topic tags.json", value);
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

        //[HttpGet("{country}/{state}/{city}/{govEntity?}/{meetingDate?}")]
        //public Addtags Get(string country, string state, string city, string govEntity = null, string meetingDate = null)
        //{
        //    return addtags.Get("johnpank", country, state, city, govEntity, meetingDate);
        //}


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
