using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.WebApp.Models;
using GM.WebApp.Features.Shared;
using GM.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IO;
using GM.FileDataRepositories;
using GM.ViewModels;
using Microsoft.Extensions.Logging;

// TODO There is probably an easier, standard, way to disable authentication in Asp.Net Core.
// $define NOAUTH       // uncomment this to disable auth. You can also define NOAUTH in project properties.


namespace GM.WebApp.Features.Addtags
{

    [Route("api/[controller]")]
    public class AddtagsController : Controller
    {
        private readonly ILogger<AddtagsController> logger;

        public IAddtagsRepository addtags { get; set; }

        public AddtagsController(IAddtagsRepository addtags, ILogger<AddtagsController> _logger)
        {
            this.addtags = addtags;
            logger = _logger;
        }

        [HttpGet("{meetingId}")]        // GET: api/addtags
        public AddtagsView Get(int meetingId)
        {
            logger.LogTrace("Get AddtagsView by meeting Id");

            AddtagsView ret = addtags.Get(meetingId);
            return ret;
        }

        //TODO Add authorization check that user's location matches that of the government entity.
        // We need to read the location from the user's claims.
#if NOAUTH
#else
        [Authorize(Policy = "Editor")]
#endif
        [HttpPost("{meetingId}")]          // POST api/addtags
        public bool Post([FromBody]AddtagsView value, int meetingId)
        //public void Post(Addtags value)
        {
            return addtags.Put(value, meetingId);        }
        }
    }
