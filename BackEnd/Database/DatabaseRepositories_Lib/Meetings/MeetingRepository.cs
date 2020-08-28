using System;
using System.Collections.Generic;
using GM.DatabaseModel;
using System.Linq;
using GM.DatabaseAccess;

namespace GM.DatabaseRepositories
{
    public class MeetingRepository : IMeetingRepository
    {
        DBOperations dBOps;
        IOGovBodyRepository _govBodyRepository;

        public MeetingRepository(DBOperations _dBOps, IOGovBodyRepository govBodyRepository)
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

        public long GetId(Meeting meeting)
        {
            // TODO - implement - return id of meeting that has same governmentBody and datetime
            return -1;
        }

        //public long GetId(long govBodyId, DateTime datetime)
        //{
        //    // TODO - implement - return meetingId of governmentBody and datetime
        //    return -1;
        //}

        public Meeting Get(long govBodyId, DateTime datetime)
        {
            // TODO - implement - return meeting of governmentBody and datetime
            return null;
        }

        public long Add(Meeting m)
        {
            // TODO - implement
            return -1;
        }

        public List<Meeting> FindAll(SourceType? sourceType, WorkStatus? workStatus, bool? approved)
        {
            // TODO - implement
            return null;
        }

        public string GetLongName(long meetingId)
        {
            return "";
        }
    }
}
