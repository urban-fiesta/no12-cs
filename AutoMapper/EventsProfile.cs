using AutoMapper;
using UrbanFiesta.AutoMapper.DTOs.Event;
using UrbanFiesta.Models;

namespace UrbanFiesta.AutoMapper
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventReadDto>();
            CreateMap<Event, EventUpdateDto>();
            
            CreateMap<EventCreateDto, Event>();
            CreateMap<EventUpdateDto, Event>();
        }
    }
}