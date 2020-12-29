using GM.Application.DTOs.GovLocations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GovLocationController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGovLocationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{location}")]
        public async Task<IList<GovLocationDto>> Get(string location)
        {
            return await Mediator.Send(new GetGovLocationQuery { Govlocation = location });
        }
    }
}
