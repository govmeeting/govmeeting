using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.DTOs.Govbodies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    public class GetGovbodiesQuery :IRequest<IList<GovbodyDto>>
    {
        public string Govlocation { get; set; }
    }
}
