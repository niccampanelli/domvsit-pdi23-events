using Application.Chart.Boundaries.ShowedUpByClient;
using Application.Chart.Boundaries.ShowedUpPercentages;
using Application.Chart.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Chart.Handlers
{
    public class ShowedUpByClientHandler : IRequestHandler<ShowedUpByClientCommand, List<ShowedUpByClientOutput>>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public ShowedUpByClientHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<List<ShowedUpByClientOutput>> Handle(ShowedUpByClientCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var getShowedUpByClientInput = new ShowedUpByClientInputDto()
                {
                    Months = input.Months
                };

                var result = await _eventUseCase.GetShowedUpByClient(getShowedUpByClientInput);

                var output = result.Select(r => new ShowedUpByClientOutput()
                {
                    EventCount = r.EventCount,
                    ClientId = r.ClientId
                }).ToList();

                return output;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return default;
        }
    }
}
