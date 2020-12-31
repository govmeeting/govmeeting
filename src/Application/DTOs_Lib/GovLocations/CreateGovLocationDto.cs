using GM.Application.AppCore.Entities.GovLocations;

namespace GM.Application.DTOs.GovLocations
{
    public class CreateGovLocationDto
    {
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }
        public string Code { get; private set; }
        public CreateGovLocationDto ParentLocation { get; set; }
    }
}
