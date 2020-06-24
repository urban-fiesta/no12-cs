using System.Collections.Generic;
using AutoMapper;
using UrbanFiesta.AutoMapper.DTOs.Ticket;
using UrbanFiesta.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UrbanFiesta.Data.Interfaces;
using System.Threading.Tasks;


namespace UrbanFiesta.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepo _repository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var ticketItems = await _repository.GetTickets();
            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(ticketItems));
        }

        [HttpGet("{id:int}", Name="GetTicketById")]
        public async Task<IActionResult> GetTicketById([FromRoute] int id)
        {
            var ticketItem = await _repository.GetTicketById(id);
            if (ticketItem != null ) return Ok(_mapper.Map<TicketReadDto>(ticketItem));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketForm ticketForm)
        {
            var ticketModel = _mapper.Map<Ticket>(ticketForm);
            var res = await _repository.CreateTicket(ticketModel);

            var ticketRdDto = _mapper.Map<TicketReadDto>(ticketModel);
            return CreatedAtRoute(nameof(GetTicketById), new {Id = ticketRdDto.id}, ticketRdDto);
            // return Ok(res);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] TicketForm ticketForm)
        {
            var ticketItem = await _repository.GetTicketById(id);
            if (ticketItem == null) return NotFound();

            _mapper.Map(ticketForm, ticketItem); //Real Update
            _repository.UpdateTicket(ticketItem); // Not Necessary

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult PartialTicketUpdate(int id, JsonPatchDocument<TicketForm> patchDoc)
        {
            var ticketItem = _repository.GetTicketById(id);
            if (ticketItem == null) return NotFound();

            var ticketToPatch = _mapper.Map<TicketForm>(ticketItem);
            patchDoc.ApplyTo(ticketToPatch, ModelState);
            if (TryValidateModel(ticketToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(ticketToPatch, ticketItem); // Real Patch
            // _repository.UpdateTicket(ticketItem); // Does Nothing

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _repository.DeleteTicket(id);

            return NoContent();
        }


        
    }
}