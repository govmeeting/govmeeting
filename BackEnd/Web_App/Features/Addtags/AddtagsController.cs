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

namespace GM.WebApp.Features.Addtags
{
    [Route("api/[controller]")]
    public class AddtagsController : Controller
    {
        public IAddtagsRepository addtags { get; set; }

        public AddtagsController(IAddtagsRepository addtags)
        {
            this.addtags = addtags;
        }
        
        [HttpGet("{meetingId}")]        // GET: api/addtags
        public AddtagsView Get(int meetingId)
        {
            AddtagsView ret = addtags.Get(meetingId);
            return ret;
        }

        //Todo-g Add authorization check that user's location matches that of the government entity.
        // We need to read the location from the user's claims.
        [Authorize(Policy = "Editor")]
        [HttpPost("{meetingId}")]          // POST api/addtags
        public void Post([FromBody]AddtagsView value, int meetingId)
        //public void Post(Addtags value)
        {
            addtags.Put(value, meetingId);        }
        }
    }
