using Application.Event.Boundaries.Accept;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Event.Handlers
{
    public class AcceptHandler : IRequestHandler<AcceptCommand, AcceptOutput>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public AcceptHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<AcceptOutput> Handle(AcceptCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var acceptInput = new AcceptInputDto()
                {
                    EventId = input.EventId,
                    AttendantId = input.AttendantId,
                    Accepted = input.Accepted
                };

                await _eventUseCase.Accept(acceptInput);

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
