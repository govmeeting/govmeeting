using GM.Application.AppCore.Entities.GovLocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class CreateGovLocationCommand : IRequest<int?>
    {
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }
        public string Code { get; private set; }
    }
}
