using GM.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseRepositories
{
    public class GovBodyRepository : IGovBodyRepository
    {
        public GovBody Get(long Id)
        {
            return new GovBody();
        }

        public long Add(GovBody govBody)
        {
            return 0;
        }

        public List<GovBody> FindThoseWithScheduledMeetings()
        {
            return new List<GovBody>();
        }
    }
}
