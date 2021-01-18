using Ardalis.Specification;

namespace GM.Application.AppCore.Entities.GovLocations
{
    public class GovLocationWithGovbodies_Spec : Specification<GovLocation>
    {
        public GovLocationWithGovbodies_Spec(int govLocationId)
        {
            Query
                .Where(b => b.Id == govLocationId)
                .Include(b => b.Govbodies);
        }
    }
}
