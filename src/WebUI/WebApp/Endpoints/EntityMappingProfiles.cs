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

            CreateMap<CreateGovLocationCommand, GovLocation>();     // for POST endpoint
            //CreateMap<CreateGovLocationDto, GovLocation>();
            CreateMap<GovLocation, CreateGovLocationDto>();         // for GET endpoint

            CreateMap<CreateGovbodyCommand, Govbody>();
            //CreateMap<GovbodyDto, Govbody>();
            CreateMap<Govbody, GovbodyDto>();

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
