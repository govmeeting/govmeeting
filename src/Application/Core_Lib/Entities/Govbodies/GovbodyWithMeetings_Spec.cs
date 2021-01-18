using Ardalis.Specification;

namespace GM.Application.AppCore.Entities.Govbodies
{
    public sealed class GovbodyWithMeetings_Spec : Specification<Govbody>
    {
        public GovbodyWithMeetings_Spec(int govbodyId)
        {
            Query
                .Where(b => b.Id == govbodyId)
                .Include(b => b.Meetings);
        }
    }
}
