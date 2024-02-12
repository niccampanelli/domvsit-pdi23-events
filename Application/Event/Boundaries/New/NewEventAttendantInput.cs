using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.New
{
    [SwaggerSchema(Required = new string[] { "AttendantId" })]
    public class NewEventAttendantInput
    {
        [SwaggerSchema(
            Title = "Id do participante",
            Description = "Id do participante do cliente que precisa estar no evento",
            Format = "long"
            )]
        public long AttendantId { get; set; }
    }
}
