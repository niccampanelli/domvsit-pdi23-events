using Application.Event.Boundaries.ShowUp;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Event.Handlers
{
    public class ShowUpHandler : IRequestHandler<ShowUpCommand, ShowUpOutput>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public ShowUpHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<ShowUpOutput> Handle(ShowUpCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var showUpInput = new ShowUpInputDto()
                {
                    EventId = input.EventId,
                    AttendantId = input.AttendantId,
                    ShowedUp = input.ShowedUp,
                };

                await _eventUseCase.ShowUp(showUpInput);

                return default;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return default;
        }
    }
}
