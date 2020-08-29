using System;
using System.Collections.Generic;
using System.Text;
using GM.DatabaseModel;


namespace GM.DatabaseRepositories
{
    public interface IGovLocationRepository
    {
        public GovLocation Get(long govLocationId);

        public long Add(GovLocation govLocation);

    }
}
