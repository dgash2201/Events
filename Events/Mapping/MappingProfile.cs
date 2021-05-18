using AutoMapper;
using Events.Data.Dto;
using Events.Data.Models;

namespace Events.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventDto, Event>()
                .ReverseMap();

            CreateMap<EventWithTeamsDto, EventWithTeamsDto>()
                .ReverseMap();
        }
    }
}
