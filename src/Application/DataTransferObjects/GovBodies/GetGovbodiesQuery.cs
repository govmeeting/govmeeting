using GM.ApplicationCore.Entities.Govbodies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.GovbodiesDto
{
    public class GetGovbodiesQuery :IRequest<IList<GovbodyDto>>
    {
        public string Govlocation { get; set; }
    }
}
