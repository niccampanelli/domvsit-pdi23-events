using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.Accept
{
    public class AcceptInput
    {
        [SwaggerSchema(
            Title = "Id do evento",
            Description = "Id do evento que o participante aceitou",
            Format = "long"
            )]
        public long EventId { get; set; }

        [SwaggerSchema(
            Title = "Id do participante",
            Description = "Id do participante que aceitou",
            Format = "long"
            )]
        public long AttendantId { get; set; }

        [SwaggerSchema(
            Title = "Aceitou",
            Description = "O cliente aceitou o evento?",
            Format = "bool"
            )]
        public bool? Accepted { get; set; }
    }
}
