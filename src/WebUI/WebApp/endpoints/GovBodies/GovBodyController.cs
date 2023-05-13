using GM.Application.DTOs.Govbodies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

//using GM.DatabaseRepositories;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    /// <summary>
    /// Process Govbodies at the local location of the current user
    /// </summary>
    //[Authorize]
    public class GovbodyController : ApiController
    {
        /// <summary>
        /// Register Govbody (or update registration)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Register(RegisterGovbody_Cmd command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Get Govbodies for a GovLocation
        /// </summary>
        /// <param name="id">GovLocation Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IList<Govbody_Dto>> GetGovbodies(int id)
        {
            return await Mediator.Send(new GetGovbodies_Query() { GovLocationId = id });
        }

        /// <summary>
        /// Get Govbody by Id
        /// </summary>
        /// <param name="id">Govbody Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<GovbodyDetails_Dto> GetGovbody(int id)
        {
            return await Mediator.Send(new GetGovbody_Query() { GovbodyId = id });
        }



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

    }
}
