using AutoMapper;
using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.GovbodiesDto;
using GM.ApplicationCore.Entities.GovLocations;
using GM.ApplicationCore.Entities.GovLocationsDto;
using GM.ApplicationCore.Entities.Topics;
using GM.ApplicationCore.Entities.TopicsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities
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
