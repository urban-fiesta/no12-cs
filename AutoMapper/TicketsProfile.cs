using AutoMapper;
using UrbanFiesta.AutoMapper.DTOs.Ticket;
using UrbanFiesta.Models;

namespace UrbanFiesta.AutoMapper
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<Ticket, TicketForm>();
            
            CreateMap<TicketReadDto, Ticket>();
            CreateMap<TicketForm, Ticket>();
        }
    }
}