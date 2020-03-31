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
        //long GetId(GovernmentBody body);
        long GetId(string country, string state, string county, string municipality);

    }
}
