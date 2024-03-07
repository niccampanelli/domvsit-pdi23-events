using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.ShowUp
{
    public class ShowUpInput
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
            Title = "Compareceu",
            Description = "O cliente comparecdu ao evento?",
            Format = "bool"
            )]
        public bool? ShowedUp { get; set; }
    }
}
