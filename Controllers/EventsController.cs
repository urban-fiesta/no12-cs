using System.Collections.Generic;
using AutoMapper;
using UrbanFiesta.AutoMapper.DTOs.Event;
using UrbanFiesta.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UrbanFiesta.Data.Interfaces;
using System.Threading.Tasks;

namespace UrbanFiesta.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepo _repository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents([FromQuery] Options opts)
        {
            var eventItems = await _repository.GetEvents(opts);
            return Ok(_mapper.Map<IEnumerable<EventReadDto>>(eventItems));
        }

        [HttpGet("{id:int}", Name="GetEventById")]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            var eventItem = await _repository.GetEventById(id);
            if (eventItem != null ) return Ok(_mapper.Map<EventReadDto>(eventItem));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateDto evtCrtDto)
        {
            var eventModel = _mapper.Map<Event>(evtCrtDto);
            var res = await _repository.CreateEvent(eventModel);

            var evtRdDto = _mapper.Map<EventReadDto>(eventModel);
            // return CreatedAtRoute(nameof(GetEventById), new {Id = evtRdDto.Id}, evtRdDto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] EventUpdateDto evtUpdDto)
        {
            var eventItem = await _repository.GetEventById(id);
            if (eventItem == null) return NotFound();

            _mapper.Map(evtUpdDto, eventItem); //Real Update
            _repository.UpdateEvent(eventItem); // Not Necessary

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult PartialEventUpdate(int id, JsonPatchDocument<EventUpdateDto> patchDoc)
        {
            var eventItem = _repository.GetEventById(id);
            if (eventItem == null) return NotFound();

            var eventToPatch = _mapper.Map<EventUpdateDto>(eventItem);
            patchDoc.ApplyTo(eventToPatch, ModelState);
            if (TryValidateModel(eventToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(eventToPatch, eventItem); // Real Patch
            // _repository.UpdateEvent(eventItem); // Does Nothing

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _repository.DeleteEvent(id);

            return NoContent();
        }


        
    }
}