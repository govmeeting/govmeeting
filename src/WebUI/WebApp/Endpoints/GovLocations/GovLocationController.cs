using GM.Application.DTOs.GovLocations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GovLocationController : ApiController
    {
        /// <summary>
        /// Register GovLocation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Register(RegisterGovLocationCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Get GovLocations for current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GovLocation_Dto>> GetMyGovLocations()
        {
            return await Mediator.Send(new GetMyGovLocations_Query());
        }

        /// <summary>
        /// Get GovLocation by Id
        /// </summary>
        /// <param name="id">Id of GovLocation</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<GovLocationDetails_Dto> GetGovLocation(int id)
        {
            return await Mediator.Send(new GetGovLocation_Query());
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<GovLocationWithGovbodies_Dto> GetMyLocalLocationWithGovbodies()
        //{
        //    return await Mediator.Send(new GetLocalGovLocationWithGovbodies_Query());
        //}

    }
}

/* Example of using an object for the query parameters
   https://stackoverflow.com/a/60652340/1978840

    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        public string Get([FromQuery] GetPersonQueryObject request)
        {
            // Your code goes here
        }
    }

    public class GetPersonQueryObject 
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
    }

*/
