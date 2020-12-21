using System;
using System.Collections.Generic;
using System.Text;

namespace GM.FileDataRepositories
{
    public interface IEditMeetingRepository
    {
        public string Get(long meetingId, int part);
        public bool Put(string value, long meetingId, int part);
    }
}
