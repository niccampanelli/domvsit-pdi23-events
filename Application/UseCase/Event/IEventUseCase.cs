﻿using Domain.Dto.Commom;
using Domain.Dto.Event;

namespace Application.UseCase.Event
{
    public interface IEventUseCase
    {
        Task<EventDto> New(EventDto input);
        Task<EventDto> Update(long id, UpdateInputDto input);
        Task<bool> Delete(long id);
        Task<bool> DeleteByParams(DeleteByParamsInputDto input);
        Task Accept(AcceptInputDto input);
        Task ShowUp(ShowUpInputDto input);
        Task<int> Count();
        Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting);
    }
}
