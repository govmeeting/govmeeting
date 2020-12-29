using GM.Application.DTOs.GovLocations;
using MediatR;
using System.Collections.Generic;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GetGovLocationQuery : IRequest<IList<GovLocationDto>>
    {
        public string Govlocation { get; set; }
    }
}
