namespace Domain.Dto.Event
{
    public class UpdateInputDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; }
        public string? Link { get; set; }
        public DateTime? Ocurrence { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<UpdateEventAttendantInputDto>? EventAttendants { get; set; }
    }
}
