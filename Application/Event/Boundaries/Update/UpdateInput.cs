using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.Update
{
    public class UpdateInput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do evento",
            Format = "long"
            )]
        public long Id { get; set; }

        [SwaggerSchema(
            Title = "Titulo",
            Description = "Titulo do evento",
            Format = "string"
            )]
        public string? Title { get; set; }

        [SwaggerSchema(
            Title = "Descrição",
            Description = "Descrição do evento",
            Format = "string"
            )]
        public string? Description { get; set; }

        [SwaggerSchema(
            Title = "Tags",
            Description = "Tags que categorizam o evento",
            Format = "List<string>"
            )]
        public List<string>? Tags { get; set; }

        [SwaggerSchema(
            Title = "Link",
            Description = "Link de encontro associado ao evento",
            Format = "string"
            )]
        public string? Link { get; set; }

        [SwaggerSchema(
            Title = "Data de ocorrência",
            Description = "Data em que o evento ocorrerá",
            Format = "DateTime"
            )]
        public DateTime? Ocurrence { get; set; }

        [SwaggerSchema(
            Title = "Participantes do evento",
            Description = "Participantes que precisam estar no evento",
            Format = "List<UpdateEventAttendantInput>"
            )]
        public List<UpdateEventAttendantInput>? EventAttendants { get; set; }
    }
}
