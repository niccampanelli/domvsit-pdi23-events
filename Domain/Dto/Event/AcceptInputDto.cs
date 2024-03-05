namespace Domain.Dto.Event
{
    public class AcceptInputDto
    {
        public long EventId { get; set; }
        public long AttendantId { get; set; }
        public bool? Accepted { get; set; }
    }
}
