using Application.Chart.Boundaries.MarkedUnmarked;
using Application.Chart.Boundaries.ShowedUpByClient;
using Application.Chart.Boundaries.ShowedUpPercentages;
using Application.Chart.Commands;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Rotas para obter gráficos")]
    public class ChartController : BaseController
    {
        private IMediatorHandler _mediatorHandler;

        public ChartController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "Porcentagem de comparecimento", Description = "Obter a porcentagem de comparecimento e não comparecimento")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(ShowedUpPercentagesOutput))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> ShowedUpPercentages([FromQuery] ShowedUpPercentagesInput input)
        {
            var command = new ShowedUpPercentagesCommand(input);
            var result = await _mediatorHandler.SendCommand<ShowedUpPercentagesCommand, ShowedUpPercentagesOutput>(command);

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
        [SwaggerOperation(Summary = "Eventos marcados e desmarcados", Description = "Quantidade de eventos marcados e desmarcados por mês")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(List<MarkedUnmarkedOutput>))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> MarkedUnmarked([FromQuery] MarkedUnmarkedInput input)
        {
            var command = new MarkedUnmarkedCommand(input);
            var result = await _mediatorHandler.SendCommand<MarkedUnmarkedCommand, List<MarkedUnmarkedOutput>>(command);

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
        [SwaggerOperation(Summary = "Eventos não comparecidos por cliente", Description = "Quantidade de eventos que não foram comparecidos por cada cliente")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(List<ShowedUpByClientOutput>))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> ShowedUpByClient([FromQuery] ShowedUpByClientInput input)
        {
            var command = new ShowedUpByClientCommand(input);
            var result = await _mediatorHandler.SendCommand<ShowedUpByClientCommand, List<ShowedUpByClientOutput>>(command);

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
        [SwaggerOperation(Summary = "Eventos não comparecidos por participantes", Description = "Quantidade de eventos que não foram comparecidos por cada participante")]
        [SwaggerResponse(201, Description = "Sucesso", Type = typeof(List<ShowedUpByClientOutput>))]
        [SwaggerResponse(400, Description = "Erros 400", Type = typeof(List<string>))]
        [SwaggerResponse(500, Description = "Erros 500", Type = typeof(List<string>))]
        public async Task<IActionResult> ShowedUpByAttendant([FromQuery] ShowedUpByClientInput input)
        {
            var command = new ShowedUpByClientCommand(input);
            var result = await _mediatorHandler.SendCommand<ShowedUpByClientCommand, List<ShowedUpByClientOutput>>(command);

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
