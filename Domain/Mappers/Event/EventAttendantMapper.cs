using Domain.Dto.Event;
using Domain.Entities.Event;

namespace Domain.Mappers.Event
{
    public static class EventAttendantMapper
    {
        public static EventAttendantEntity MapToEntity(this EventAttendantDto input)
        {
            return new EventAttendantEntity()
            {
                Id = input.Id,
                EventId = input.EventId,
                AttendantId = input.AttendantId,
                Accepted = input.Accepted,
                ShowedUp = input.ShowedUp
            };
        }

        public static EventAttendantDto MapToDto(this EventAttendantEntity input)
        {
            return new EventAttendantDto()
            {
                Id = input.Id,
                EventId = input.EventId,
                AttendantId = input.AttendantId,
                Accepted = input.Accepted,
                ShowedUp = input.ShowedUp
            };
        }
    }
}
