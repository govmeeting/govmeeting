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
            CreateMap<RegisterGovLocation_Cmd, GovLocation>();
            CreateMap<GovLocation, GovLocation_Dto>();
            CreateMap<GovLocation, GovLocationDetails_Dto>();

            CreateMap<RegisterGovbody_Cmd, Govbody>();
            CreateMap<Govbody, Govbody_Dto>();
            CreateMap<Govbody, GovbodyDetails_Dto>();
            CreateMap<GovbodyDetails_Dto, Govbody>();

            CreateMap<ElectedOfficial_Dto, ElectedOfficial>();
            CreateMap<AppointedOfficial_Dto, AppointedOfficial>();
            CreateMap<ElectedOfficial, ElectedOfficial_Dto>();
            CreateMap<AppointedOfficial, AppointedOfficial_Dto>();


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
