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
        /// <returns>Id of new GovLocation</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Register(RegisterGovLocation_Cmd command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Get GovLocations for current user
        /// </summary>
        /// <returns>List of current user's GovLocations </returns>
        [HttpGet]
        //public async Task<List<GovLocation_Dto>> GetMyGovLocations(GetMyGovLocations_Query query)
        //{
        //    return await Mediator.Send(query);
        //}
        public async Task<IEnumerable<GovLocation_Dto>> GetMyGovLocations()
        {
            GetMyGovLocations_Query g = new GetMyGovLocations_Query();
            //return await Mediator.Send(new GetMyGovLocations_Query());
            return await Mediator.Send(g);
        }

        // TODO - This returns too much data
        ///// <summary>
        ///// Get GovLocation by Id
        ///// </summary>
        ///// <param name="id">Id of GovLocation</param>
        ///// <returns>specified GovLocation</returns>
        //[HttpGet("{id}")]
        //public async Task<GovLocationDetails_Dto> GetGovLocation(int id)
        //{
        //    return await Mediator.Send(new GetGovLocation_Query());
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
