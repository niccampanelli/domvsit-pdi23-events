using Application.Boundaries.Commom;
using Application.Event.Boundaries.List;
using Application.Event.Boundaries.New;
using Application.Event.Boundaries.Update;
using Application.Event.Commands;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Rotas para gerenciar eventos")]
    public class EventController : BaseController
    {
        private IMediatorHandler _mediatorHandler;

        public EventController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost("[action]")]
        [SwaggerOperation(Summary = "Agendar evento", Description = "Agendar um novo evento.")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(NewOutput))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> New([FromBody] NewControllerInput input)
        {
            var userIdHeader = Request.Headers["User-Id"].FirstOrDefault();

            if (userIdHeader == null)
            {
                return BadRequest(new string[]
                {
                    "O id do consultor precisa ser informado"
                });
            }

            var commandInput = new NewInput()
            {
                Title = input.Title,
                Description = input.Description,
                Tags = input.Tags,
                EventAttendants = input.EventAttendants,
                Link = input.Link,
                Ocurrence = input.Ocurrence,
                ConsultorId = long.Parse(userIdHeader),
                ClientId = input.ClientId
            };

            var command = new NewCommand(commandInput);
            var result = await _mediatorHandler.SendCommand<NewCommand, NewOutput>(command);

            if (IsValidOperation())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "Listar eventos", Description = "Obter todos os eventos filtrados, ordenados e paginados")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(PaginatedResponse<ListOutput>))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> List([FromQuery] ListInput input)
        {
            var command = new ListCommand(input);
            var result = await _mediatorHandler.SendCommand<ListCommand, PaginatedResponse<ListOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPut("[action]/{id}")]
        [SwaggerOperation(Summary = "Atualizar evento", Description = "Atualiza as informações de um evento.")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(UpdateOutput))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateControllerInput input)
        {
            var commandInput = new UpdateInput()
            {
                Id = id,
                Title = input.Title,
                Description = input.Description,
                Link = input.Link,
                Tags = input.Tags,
                Ocurrence = input.Ocurrence,
                EventAttendants = input.EventAttendants
            };

            var command = new UpdateCommand(commandInput);
            var result = await _mediatorHandler.SendCommand<UpdateCommand, UpdateOutput>(command);

            if (IsValidOperation())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
