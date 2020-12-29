using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace GM.Application.AppCore.Entities.Govbodies
{
    public static class GovbodyGuards
    {
        public static void NullGovbody(this IGuardClause guardClause, int govbodyId, Govbody govbody)
        {
            if (govbody == null)
                throw new GovbodyNotFoundException(govbodyId);
        }
    }
}