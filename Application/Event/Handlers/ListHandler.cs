using Application.Boundaries.Commom;
using Application.Event.Boundaries.List;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Commom;
using Domain.Dto.Event;
using MediatR;

namespace Application.Event.Handlers
{
    public class ListHandler : IRequestHandler<ListCommand, PaginatedResponse<ListOutput>>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public ListHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<PaginatedResponse<ListOutput>> Handle(ListCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var eventCount = await _eventUseCase.Count();

                var listInput = new ListInputDto()
                {
                    ConsultorId = input.ConsultorId,
                    ClientId = input.ClientId,
                    OcurrenceMin = input.OcurrenceMin,
                    OcurrenceMax = input.OcurrenceMax,
                    ShowUnmarked = input.ShowUnmarked,
                    Search = input.Search
                };

                var paginationInput = new PaginationInputDto()
                {
                    Limit = input.Limit,
                    Page = input.Page
                };

                var sortingInput = new SortingInputDto()
                {
                    SortField = input.SortField,
                    SortOrder = input.SortOrder
                };

                var eventList = await _eventUseCase.List(listInput, paginationInput, sortingInput);

                var eventCountInList = eventList.Count();

                var output = new PaginatedResponse<ListOutput>()
                {
                    CurrentPage = input.Page ?? 1,
                    ItemsCount = eventCountInList,
                    Data = eventList.Select(e => new ListOutput()
                    {
                        Id = e.Id ?? 0L,
                        Title = e.Title,
                        Description = e.Description,
                        Tags = e.Tags,
                        Link = e.Link,
                        ConsultorId = e.ConsultorId,
                        ClientId = e.ClientId,
                        Ocurrence = e.Ocurrence,
                        CreatedAt = e.CreatedAt ?? DateTime.UtcNow,
                        UpdatedAt = e.UpdatedAt ?? DateTime.UtcNow,
                        Status = e.Status,
                        EventAttendants = e.EventAttendants.Select(e => new ListEventAttendantOutput()
                        {
                            Id = e.Id ?? 0L,
                            AttendantId = e.AttendantId,
                            EventId = e.EventId ?? 0L,
                            Accepted = e.Accepted,
                            ShowedUp = e.ShowedUp
                        }).ToList()
                    }).ToList(),
                    Total = eventCount
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
