using Domain.Dto.Commom;
using Domain.Dto.Event;

namespace Application.UseCase.Event
{
    public interface IEventUseCase
    {
        Task<EventDto> New(EventDto input);
        Task<int> Count();
        Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting);
    }
}
