namespace Domain.Dto.Event
{
    public class EventAttendantDto
    {
        public long? Id { get; set; }
        public long? EventId { get; set; }
        public long AttendantId { get; set; }
        public bool Accepted { get; set; }
        public bool ShowedUp { get; set; }
    }
}
