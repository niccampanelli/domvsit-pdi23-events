using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.List
{
    public class ListEventAttendantOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do relacionamento",
            Format = "long"
            )]
        public long Id { get; set; }

        [SwaggerSchema(
            Title = "Id do evento",
            Description = "Id do evento relacionado",
            Format = "long"
            )]
        public long EventId { get; set; }

        [SwaggerSchema(
            Title = "Id do participante",
            Description = "Id do participante relacionado",
            Format = "long"
            )]
        public long AttendantId { get; set; }

        [SwaggerSchema(
            Title = "Aceito",
            Description = "O participante aceitou o evento",
            Format = "bool"
            )]
        public bool Accepted { get; set; }

        [SwaggerSchema(
            Title = "Apareceu",
            Description = "O participante compareceu ao evento",
            Format = "bool"
            )]
        public bool ShowedUp { get; set; }
    }
}
