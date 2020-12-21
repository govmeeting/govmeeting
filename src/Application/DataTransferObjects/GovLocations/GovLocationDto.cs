using GM.ApplicationCore.Entities.GovLocations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.GovLocationsDto
{
    public class GovLocationDto
    {
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }

    }
}
