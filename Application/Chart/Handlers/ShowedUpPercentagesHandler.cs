using Application.Chart.Boundaries.ShowedUpPercentages;
using Application.Chart.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Chart.Handlers
{
    public class ShowedUpPercentagesHandler : IRequestHandler<ShowedUpPercentagesCommand, ShowedUpPercentagesOutput>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public ShowedUpPercentagesHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<ShowedUpPercentagesOutput> Handle(ShowedUpPercentagesCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var getPercentagesInput = new ShowedUpPercentagesInputDto()
                {
                    Months = input.Months
                };

                var percentage = await _eventUseCase.GetShowedUpPercentages(getPercentagesInput);

                var output = new ShowedUpPercentagesOutput()
                {
                    ShowedUpPercentage = percentage
                };

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
