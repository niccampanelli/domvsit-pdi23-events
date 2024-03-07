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
                Status = input.Status,
                EventAttendants = input.EventAttendants != null ? input.EventAttendants.Select(e => e.MapToEntity()).ToList() : new List<EventAttendantEntity>()
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
                Status = input.Status,
                EventAttendants = input.EventAttendants != null ? input.EventAttendants.Select(e => e.MapToDto()).ToList() : new List<EventAttendantDto>()
            };
        }

        public static EventEntity UpdateEntity(this EventEntity entity, UpdateInputDto input)
        {
            entity.Title = input.Title ?? entity.Title;
            entity.Description = input.Description ?? entity.Description;
            entity.Tags = input.Tags ?? entity.Tags;
            entity.Link = input.Link ?? entity.Link;
            entity.ConsultorId = entity.ConsultorId;
            entity.ClientId = entity.ClientId;
            entity.Ocurrence = input.Ocurrence ?? entity.Ocurrence;
            entity.CreatedAt = entity.CreatedAt;
            entity.UpdatedAt = input.UpdatedAt;
            entity.Status = input.Status == null ? entity.Status : (bool)input.Status;
            entity.EventAttendants ??= new List<EventAttendantEntity>();

            return entity;
        }
    }
}
