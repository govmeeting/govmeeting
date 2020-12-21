using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.GovLocationsDto
{
    class GetGovLocationQuery : IRequest<IList<GovLocationDto>>
    {
    }
}
