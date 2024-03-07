using Application.Event.Boundaries.Update;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
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
                var input = command.Input;

                var updateInput = new UpdateInputDto()
                {
                    Title = input.Title,
                    Description = input.Description,
                    Tags = input.Tags,
                    Link = input.Link,
                    Ocurrence = input.Ocurrence,
                    Status = input.Status,
                    EventAttendants = input.EventAttendants != null ? input.EventAttendants.Select(e => new UpdateEventAttendantInputDto()
                    {
                        AttendantId = e.AttendantId
                    }).ToList() : null
                };

                var result = await _eventUseCase.Update(input.Id, updateInput);

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
