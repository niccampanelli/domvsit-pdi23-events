namespace Application.Event.Boundaries.List
{
    public class ListEventAttendantOutput
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long AttendantId { get; set; }
    }
}
