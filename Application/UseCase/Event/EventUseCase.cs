﻿using Domain.Dto.Commom;
using Domain.Dto.Event;
using Domain.Repository;

namespace Application.UseCase.Event
{
    public class EventUseCase : IEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public EventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventDto> New(EventDto input)
        {
            input.CreatedAt = DateTime.UtcNow;
            input.UpdatedAt = DateTime.UtcNow;
            return await _eventRepository.New(input);
        }

        public async Task<int> Count()
        {
            return await _eventRepository.Count();
        }

        public async Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting)
        {
            return await _eventRepository.List(input, pagination, sorting);
        }
    }
}
