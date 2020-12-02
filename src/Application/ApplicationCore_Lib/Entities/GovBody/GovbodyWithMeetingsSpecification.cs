using Ardalis.Specification;

namespace GM.ApplicationCore.Entities.GovBodies
{
    public sealed class GovbodyWithMeetingsSpecification : Specification<GovBody>
    {
        public GovbodyWithMeetingsSpecification(int govbodyId)
        {
            Query
                .Where(b => b.Id == govbodyId)
                .Include(b => b.Meetings);
        }
    }
}
