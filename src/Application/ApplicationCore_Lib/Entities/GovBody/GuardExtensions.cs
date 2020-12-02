using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace GM.ApplicationCore.Entities.GovBodies
{
    public static class GovbodyGuards
    {
        public static void NullGovbody(this IGuardClause guardClause, int govbodyId, GovBody govbody)
        {
            if (govbody == null)
                throw new GovbodyNotFoundException(govbodyId);
        }
    }
}