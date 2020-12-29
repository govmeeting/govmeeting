using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GM.WebUI.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;
using GM.Application.AppCore.Interfaces;
using GM.Application.DTOs.Govbodies;


//using GM.DatabaseRepositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{

    //[Authorize]
    public class GovbodyController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGovbodyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{location}")]
        public async Task<IList<GovbodyDto>> Get(string location)
        {
            return await Mediator.Send(new GetGovbodiesQuery { Govlocation = location });
        }


        //[Route("api/[controller]")]
        //    public class GovbodyController : Controller
        //    {
        //        IAsyncRepository<Govbody> _govbodyRepository;
        //        IAsyncRepository<GovLocation> _govlocationRepository;

        //        public GovbodyController(
        //            IAsyncRepository<Govbody> govbodyRepository,
        //            IAsyncRepository<GovLocation> govlocationRepository
        //        )
        //        {
        //            _govbodyRepository = govbodyRepository;
        //            _govlocationRepository = govlocationRepository;
        //        }

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
        ////public Govbody Get(int govBodyId)
        ////{
        ////    Govbody ret = dbOps.GetGovbody(govBodyId);
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
