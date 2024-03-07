namespace Domain.Dto.Event
{
    public class ShowUpInputDto
    {
        public long EventId { get; set; }
        public long AttendantId { get; set; }
        public bool? ShowedUp { get; set; }
    }
}
