namespace Domain.Dto.Event
{
    public class ListInputDto
    {
        public long? ConsultorId { get; set; }
        public long? ClientId { get; set; }
        public DateTime? OcurrenceMin { get; set; }
        public DateTime? OcurrenceMax { get; set; }
        public string? Search { get; set; }
    }
}
