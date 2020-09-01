using System;
using System.Collections.Generic;
using System.Text;
using GM.DatabaseModel;

namespace GM.DatabaseRepositories
{
    public interface IGovBodyRepository
    {
        GovBody Get(long Id);

        public long Add(GovBody govBody);

        public List<GovBody> FindThoseWithScheduledMeetings();
    }
}
