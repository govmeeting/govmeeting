using Ardalis.Specification;

namespace GM.ApplicationCore.Entities.Meetings
{
    /* Specification to return meetings from a government body
     * with the (optionally) specified SourceType and WorkStatus.
     */
    public class MeetingFilterSpecification : Specification<Meeting>
    {
        public MeetingFilterSpecification(
            long govBodyId,
            SourceType? sourceType,
            WorkStatus? workStatus,
            bool? approved)
        {
            Query.Where(i => 
            (govBodyId == i.GovbodyId) && 
            (!sourceType.HasValue || i.SourceType == sourceType) &&
            (!workStatus.HasValue || i.WorkStatus == workStatus) &&
            (!approved.HasValue || i.Approved == approved));
        }
    }
}

