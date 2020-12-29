using GM.Application.AppCore.Entities.GovLocations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Application.DTOs.GovLocations
{
    public class GovLocationDto
    {
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }

    }
}
