using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GM.Infrastructure.FileDataRepositories.ViewMeetings
{
    public interface IViewMeetingRepository
    {
        public string Get(long meetingId);
        public bool Put(long meetingId, string meeting);
    }
}
