using GM.ApplicationCore.Entities.GovLocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.GovLocationsDto
{
    class CreateGovLocationCommand : IRequest<int?>
    {
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }
        public string Code { get; private set; }
    }
}
