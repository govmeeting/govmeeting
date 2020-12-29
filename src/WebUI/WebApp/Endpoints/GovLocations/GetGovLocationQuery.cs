using GM.Application.DTOs.GovLocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    class GetGovLocationQuery : IRequest<IList<GovLocationDto>>
    {
    }
}
