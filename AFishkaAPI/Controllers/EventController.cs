using AFishka.Application.Events.Commands.CreateEvent;
using AFishka.Application.Events.Commands.DeleteEvent;
using AFishka.Application.Events.Queries.GetEventDetails;
using AFishka.Application.Events.Queries.GetEventList;
using AFishkaAPI.Models;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AFishkaAPI.Controllers
{
    // TODO: Check
    [Route("[controller]/[action]")]
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;
        public EventController(IMapper mapper) => _mapper = mapper;

        [HttpGet] // TODO: чекнуть экшнрезульт
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsVm>> Get(Guid id, 
            [FromServices] IValidator<GetEventDetailsQuery> validator)
        {
            var query = new GetEventDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            validator.ValidateAndThrow(query);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto createEventDto, 
            [FromServices] IValidator<CreateEventCommand> validator)
        {
            var command = _mapper.Map<CreateEventCommand>(createEventDto);
            command.UserId = UserId;
            validator.ValidateAndThrow(command);
            var noteId = await Mediator.Send(command);
            return Created(string.Empty, noteId);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,
            [FromServices] IValidator<DeleteEventCommand> validator)
        {
            var command = new DeleteEventCommand
            {
                Id = id,
                UserId = UserId
            };
            validator.ValidateAndThrow(command);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
