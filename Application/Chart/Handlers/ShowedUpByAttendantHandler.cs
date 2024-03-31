using Application.Chart.Boundaries.MarkedUnmarked;
using Application.Chart.Boundaries.ShowedUpByAttendant;
using Application.Chart.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Chart.Handlers
{
    public class ShowedUpByAttendantHandler : IRequestHandler<ShowedUpByAttendantCommand, List<ShowedUpByAttendantOutput>>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public ShowedUpByAttendantHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<List<ShowedUpByAttendantOutput>> Handle(ShowedUpByAttendantCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var getShowedUpByAttendantInput = new ShowedUpByAttendantInputDto()
                {
                    Months = input.Months,
                    ClientId = input.ClientId
                };

                var result = await _eventUseCase.GetShowedUpByAttendant(getShowedUpByAttendantInput);

                var output = result.Select(r => new ShowedUpByAttendantOutput()
                {
                    EventCount = r.EventCount,
                    AttendantId = r.AttendantId
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
