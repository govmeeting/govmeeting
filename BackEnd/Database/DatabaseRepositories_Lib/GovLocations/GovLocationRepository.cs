using System;
using System.Collections.Generic;
using System.Text;
using GM.DatabaseModel;

namespace GM.DatabaseRepositories
{
    public class GovLocationRepository : IGovLocationRepository
    {
        public GovLocation Get(long govLocationId)
        {
            return new GovLocation();
        }

        public long Add(GovLocation govLocation)
        {
            return 0;
        }

    }
}
