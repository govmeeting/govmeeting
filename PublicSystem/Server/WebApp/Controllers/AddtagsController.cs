using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AddtagsController : Controller
    {
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
            //return addtags.GetByPath("assets/Philadelphia_CityCouncil_03_17_2016 - Copy.json");
            //return addtags.GetStringByPath("assets/Philadelphia_CityCouncil_03_17_2016.json");
            return addtags.GetByPath("assets/Philadelphia_CityCouncil_03_17_2016.json");
        }

        // POST api/addtags
        [HttpPost]
        //public void Post([FromBody]string value)
        public void Post([FromBody]Addtags value)
        {
            addtags.PutByPath("assets/Philadelphia_CityCouncil_03_17_2016 - Backup.json", value);

        }
    }

}
