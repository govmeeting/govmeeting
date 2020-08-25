using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.DatabaseModel;

namespace GM.DatabaseRepositories
{
    public interface IGovBodyRepository
    {
        GovernmentBody Get(long govBodyId);
        
        long GetIdOfMatching(string country, string state, string county, string municipality);

        long GetIdOfMatching(GovernmentBody govBody);

        GovernmentBody GetMatching(string country, string state, string county, string municipality);

        GovernmentBody GetMatching(GovernmentBody govBody);

        long Add(GovernmentBody govBody);
    }
}
