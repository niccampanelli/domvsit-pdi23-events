using Application.Event.Boundaries.New;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Event.Handlers
{
    public class NewHandler : IRequestHandler<NewCommand, NewOutput>
    {
        private IMediatorHandler _mediatorHandler;
        private IEventUseCase _eventUseCase;

        public NewHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<NewOutput> Handle(NewCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                if (input.Ocurrence <= DateTime.UtcNow)
                {
                    var message = "A data de ocorrência do evento deve ser uma data futura";
                    await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, message));
                    return default;
                }

                var newInput = new EventDto()
                {
                    Title = input.Title,
                    Description = input.Description,
                    Tags = input.Tags,
                    Link = input.Link,
                    ConsultorId = input.ConsultorId,
                    Ocurrence = input.Ocurrence,
                    EventAttendants = input.EventAttendants.Select(e => new EventAttendantDto()
                    {
                        AttendantId = e.AttendantId
                    }).ToList(),
                };

                var newResult = await _eventUseCase.New(newInput);

                var output = new NewOutput()
                {
                    CreatedId = newResult.Id ?? 0L
                };

                return output;
            };

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return default;
        }
    }
}
