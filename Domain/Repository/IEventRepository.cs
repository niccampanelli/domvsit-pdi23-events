﻿using Domain.Dto.Commom;
using Domain.Dto.Event;

namespace Domain.Repository
{
    public interface IEventRepository
    {
        Task<EventDto> New(EventDto input);
        Task<EventDto> Update(long id, UpdateInputDto input);
        Task<int> Count();
        Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting);
    }
}
