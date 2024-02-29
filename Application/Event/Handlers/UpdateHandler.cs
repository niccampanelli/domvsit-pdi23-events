using Application.Event.Boundaries.Update;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using MediatR;

namespace Application.Event.Handlers
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateOutput>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public UpdateHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<UpdateOutput> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {

            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return default;
        }
    }
}
