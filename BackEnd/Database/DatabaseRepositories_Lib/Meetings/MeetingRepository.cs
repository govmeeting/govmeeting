using System;
using System.Collections.Generic;
using GM.DatabaseModel;
using System.Linq;
using GM.DatabaseAccess;

namespace GM.DatabaseRepositories
{
    public class MeetingRepository : IMeetingRepository
    {
        dBOperations dBOps;
        IGovBodyRepository _govBodyRepository;

        public MeetingRepository(dBOperations _dBOps, IGovBodyRepository govBodyRepository)
        {
            dBOps = _dBOps;
            _govBodyRepository = govBodyRepository;
        }

        public Meeting Get(long meetingId)
        {
            //dBOperations dbo = new dBOperations(); 
            Meeting meeting = dBOps.GetMeeting(meetingId);
            return meeting;
        }
    }
}
