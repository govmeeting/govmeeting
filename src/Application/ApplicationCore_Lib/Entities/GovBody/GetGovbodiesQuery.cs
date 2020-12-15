using GM.ApplicationCore.Entities.Govbodies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.Govbodies
{
    public class GetGovbodiesQuery :IRequest<IList<GovbodyVm>>
    {
        public string Govlocation { get; set; }
    }
}
