using Domain.Dto.Event;
using Domain.Entities.Event;

namespace Domain.Mappers.Event
{
    public static class EventMapper
    {
        public static EventEntity MapToEntity(this EventDto input)
        {
            return new EventEntity()
            {
                Id = input.Id,
                Title = input.Title,
                Description = input.Description,
                Tags = input.Tags,
                Link = input.Link,
                ConsultorId = input.ConsultorId,
                ClientId = input.ClientId,
                Ocurrence = input.Ocurrence,
                CreatedAt = input.CreatedAt,
                UpdatedAt = input.UpdatedAt,
                EventAttendants = input.EventAttendants.Select(e => e.MapToEntity()).ToList()
            };
        }

        public static EventDto MapToDto(this EventEntity input)
        {
            return new EventDto()
            {
                Id = input.Id,
                Title = input.Title,
                Description = input.Description,
                Tags = input.Tags,
                Link = input.Link,
                ConsultorId = input.ConsultorId,
                ClientId = input.ClientId,
                Ocurrence = input.Ocurrence,
                CreatedAt = input.CreatedAt,
                UpdatedAt = input.UpdatedAt,
                EventAttendants = input.EventAttendants.Select(e => e.MapToDto()).ToList()
            };
        }
    }
}
