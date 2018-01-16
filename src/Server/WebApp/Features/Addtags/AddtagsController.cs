using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IO;

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
        private readonly TypedOptions _options;

        public AddtagsController(IAuthorizationService authz, IAddtagsRepository addtags,
            IOptions<TypedOptions> optionsAccessor)
        {
            _authz = authz;
            this.addtags = addtags;
            _options = optionsAccessor.Value;
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
            string baseMeetingFolder = @"USA_PA_Philadelphia_Philadelphia_CityCouncil\2014-09-25";
            //string baseMeetingFolder = @"USA_PA_Philadelphia_Philadelphia_CityCouncil\2016-03-17"
            // If our test data is not already in "Datafiles", copy it from testdata folder.
            string meetingFolder = Path.Combine(_options.DatafilesPath, baseMeetingFolder);
            string testFolder = Path.Combine(_options.DatafilesPath, @"..\testdata");
            string testMeetingFolder = Path.Combine(testFolder, baseMeetingFolder);

            if (!Directory.Exists(meetingFolder))
            {
                Directory.CreateDirectory(meetingFolder);
                CopyFilesRecursively(new DirectoryInfo(testMeetingFolder), new DirectoryInfo(meetingFolder));
            }

            // Normally Get() would receive the paramaters that we are passing below to addtags.Get(). For now, this is hard-coded.
            //Addtags ret = addtags.Get("johnpank", "USA", "PA", "Philadelphia", "Philadelphia", "CityCouncil", "2016-03-17");
            Addtags ret = addtags.Get("johnpank", "USA", "PA", "Philadelphia", "Philadelphia", "CityCouncil", "2014-09-25");
            return ret;
        }

        // POST api/addtags
        [Authorize(Policy = "Editor")]
        [HttpPost]
        //public void Post([FromForm]string value)
        public void Post([FromBody]Addtags value)
        //public void Post(Addtags value)
        {
            //Todo-g Add authorization check that user's location matches that of the government entity.
            // We need to read the location from the user's claims.

            //addtags.Put("johnpank", "USA", "PA", "Philadelphia", "CityCouncil", "2016-03-17");
            //string path = @"USA_PA_Philadelphia_CityCouncil/2016-03-17\Step 3 - JSON output.pdf";
            //addtags.PutByPath(System.IO.Path.Combine(Common.getDataPath(), path), value);
            addtags.Put(value, "johnpank", "USA", "PA", "Philadelphia", "Philadelphia", "CityCouncil", "2016-03-17");
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
                string path = @"Philadelphia_CityCouncil_03_17_2016 - Backup.json";
                addtags.PutByPath(System.IO.Path.Combine(Common.getDataPath(), path), value);
                // What do I return?
            } else
            {
               // Is this correct?
                return new ChallengeResult();
            }
        }
        */

        public void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }
    }
}
