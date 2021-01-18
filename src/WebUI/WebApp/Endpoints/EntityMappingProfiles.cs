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
            CreateMap<RegisterGovLocationCommand, GovLocation>();
            CreateMap<GovLocation, GovLocation_Dto>();
            CreateMap<GovLocation, GovLocationDetails_Dto>();

            CreateMap<RegisterGovbody_Command, Govbody>();
            CreateMap<Govbody, Govbody_Dto>();
            CreateMap<Govbody, GovbodyDetails_Dto>();
            CreateMap<GovbodyDetails_Dto, Govbody>();

            //CreateMap<GetLocalGovbody_Query, RegisterGovbodyDto>();

            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();


            //// Example of using "ContructUsing".
            //CreateMap<Topic, TopicDto>().ConstructUsing(i => new TopicDto
            //{
            //    Id = i.TopicId,
            //    Name = i.TopicName,
            //});

        }
    }
}
