using System;
using System.Collections.Generic;
using System.Linq;
using GM.DatabaseAccess;
using GM.DatabaseModel;

namespace GM.DatabaseRepositories
{
    public class OGovBodyRepository : IOGovBodyRepository
    {
        DBOperations dBOperations;

        public OGovBodyRepository(DBOperations _dBOperations)
        {
            dBOperations = _dBOperations;
        }

        public GovernmentBody Get(long governmentBodyId)
        {
            GovernmentBody govBody = dBOperations.GetGovernmentBody(governmentBodyId);
            return govBody;
        }
        public long GetIdOfMatching(string country, string state, string county, string municipality)
        {
            // TODO - implement - return ID of body based on country, state, county & municipality.
            return -1;
        }

        public long GetIdOfMatching(GovernmentBody g)
        {
            // TODO - implement - return ID of body based on country, state, county & municipality.
            return -1;
        }

        public GovernmentBody GetMatching(string country, string state, string county, string municipality)
        {
            // TODO - implement - return ID of body based on country, state, county & municipality.
            return null;
        }

        public GovernmentBody GetMatching(GovernmentBody g)
        {
            // TODO - implement - return ID of body based on country, state, county & municipality.
            return null;
        }

        public long Add(GovernmentBody g)
        {
            // TODO implement
            return -1;
        }

    }
}
