using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GM.DatabaseModel;

// Experiment with specification pattern - (not yet used)

namespace DatabaseAccess_Lib
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }

    public class HasScheduledMeetings_Spec : Specification<GovBody>
    {
        public override Expression<Func<GovBody, bool>> ToExpression()
        {
            return gb => gb.ScheduledMeetings.Count > 0;
        }
    }
}
