using Application.Chart.Boundaries.MarkedUnmarked;
using Application.Chart.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Chart.Handlers
{
    public class MarkedUnmarkedHandler : IRequestHandler<MarkedUnmarkedCommand, List<MarkedUnmarkedOutput>>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public MarkedUnmarkedHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<List<MarkedUnmarkedOutput>> Handle(MarkedUnmarkedCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var getMarkedUnmarkedInput = new MarkedUnmarkedInputDto()
                {
                    Months = input.Months
                };

                var result = await _eventUseCase.GetMarkedUnmarked(getMarkedUnmarkedInput);

                var output = result.Select(r => new MarkedUnmarkedOutput()
                {
                    Marked = r.Marked,
                    Unmarked = r.Unmarked,
                    Month = r.Month,
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
