using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// This is preliminary work on a controller that will serve video files.
// THis would allow us to:
//   * not need to configure the DATAFILES folder as a static file provider.
//   * not require the ClientApp to know the exact file location of all video files that it requests.

namespace GM.WebUI.WebApp.Features.Video
{
    //[Produces("application/json")]
    [Produces("video/mp4")]
    [Route("api/Video")]
    public class VideoController : Controller
    {
        [HttpGet("{filename}")]
        public ActionResult Get(string filename)
        //[HttpGet]
        //public ActionResult Get()
        {
            string _filename = filename;
            //Fixasr ret = fixasr.Get("johnpank", "USA", "ME", "LincolnCounty", "BoothbayHarbor", "Selectmen", "2016-10-11");
            //return ret;
            string videoPath = "assets/shortvideo/" + "2016 - 10 - 11 Boothbay Harbor Selectmen(3 minutes).mp4";
            return File(videoPath, "video/mp4");
        }

    }
}