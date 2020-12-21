using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.GovLocations
{
    public enum GovlocTypes : int
    {
        City = 0,
        Town = 1,
        Borough = 2,
        Township = 3,
        County = 4,
        StateOrProvince = 5,
        Territory = 6,
        Country = 7
    };
}
