using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.GovLocations;
using MediatR;
using System.Collections.Generic;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class CreateGovLocationCommand : IRequest<int?>
    {
        public CreateGovLocationCommand()
        {
            this.Govbodies = new List<Govbody>();
        }
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }
        public string Code { get; private set; }
        public GovLocation ParentLocation { get; set; }
        public List<Govbody> Govbodies { get; set; }
    }
}
