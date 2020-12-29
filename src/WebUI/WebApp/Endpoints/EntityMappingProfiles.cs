using AutoMapper;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.AppCore.Entities.Topics;
using GM.Application.DTOs.Govbodies;
using GM.Application.DTOs.GovLocations;
using GM.Application.DTOs.Topics;
using GM.WebUI.WebApp.Endpoints.Govbodies;
using GM.WebUI.WebApp.Endpoints.GovLocations;

namespace GM.WebUI.WebApp.Endpoints
{
    public class EntityMappingProfiles : Profile
    {
        public EntityMappingProfiles()
        {
            CreateMap<Govbody, GovbodyDto>();
            CreateMap<Topic, TopicDto>().ConstructUsing(i => new TopicDto
            {
                Id = i.Id,
                Name = i.Name,
            });
            CreateMap<GovLocation, GovLocationDto>();

            CreateMap<GovbodyDto, Govbody>();
            CreateMap<TopicDto, Topic>();
            CreateMap<GovLocationDto, GovLocation>();

            CreateMap<CreateGovbodyCommand, Govbody>();
            CreateMap<CreateGovLocationCommand, GovLocation>();
        }
    }
}
