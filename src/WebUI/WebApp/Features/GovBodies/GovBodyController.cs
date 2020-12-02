using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GM.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using GM.ApplicationCore.Entities.GovBodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;
using GM.ApplicationCore.Interfaces;
using GM.ViewModels;


//using GM.DatabaseRepositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.Webapp.Features.Govbodies
{


[Route("api/[controller]")]
    public class GovBodyController : Controller
    {
        IAsyncRepository<GovBody> _govbodyRepository;
        IAsyncRepository<GovLocation> _govlocationRepository;

        public GovBodyController(
            IAsyncRepository<GovBody> govbodyRepository,
            IAsyncRepository<GovLocation> govlocationRepository
        )
        {
            _govbodyRepository = govbodyRepository;
            _govlocationRepository = govlocationRepository;
        }

        // POST: /Govbody/Register
        [HttpPost]
        public void Register(RegisterGovbodyDto model)
        {

            //_govlocationRepository.AddAsync(govlocation);
            //_govbodyRepository.
            //await _basketRepository.AddAsync(userBasket);
        }


        ////public DBOperations dbOps { get; set; }

        ////public GovernmentBodyController(DBOperations _dbOps)
        ////{
        ////    this.dbOps = _dbOps;
        ////}

        ////[HttpGet("{meetingId}")]
        ////public GovBody Get(int govBodyId)
        ////{
        ////    GovBody ret = dbOps.GetGovBody(govBodyId);
        ////    return ret;
        ////}



        //[HttpGet("{country}/{state}/{county}/{city}/{govEntity?}/{meetingDate?}")]
        //public ViewMeeting Get(string country, string state, string county, string city, string govEntity = "Selectmen", string language = "en", string meetingDate = null)
        //{
        //    return meetings.Get(country, state, county, city, govEntity, language, meetingDate);
        //}

        //// POST api/meeting
        //[HttpPost]
        //[Authorize("PhillyEditor")]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/meeting/5
        //[Authorize("PhillyEditor")]
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        //// DELETE api/meeting/5
        //[Authorize("PhillyEditor")]
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
    }
