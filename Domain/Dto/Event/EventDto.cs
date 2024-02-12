namespace Domain.Dto.Event
{
    public class EventDto
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string>? Tags { get; set; }
        public string? Link { get; set; }
        public long ConsultorId { get; set; }
        public DateTime Ocurrence { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<EventAttendantDto> EventAttendants { get; set; }
    }
}
