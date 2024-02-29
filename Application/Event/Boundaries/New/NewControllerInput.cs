using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.New
{
    [SwaggerSchema(Required = new string[] { "Title", "Description", "Ocurrence", "ClientId", "EventAttendants" })]
    public class NewControllerInput
    {
        [SwaggerSchema(
            Title = "Titulo",
            Description = "Titulo do evento",
            Format = "string"
            )]
        public string Title { get; set; }

        [SwaggerSchema(
            Title = "Descrição",
            Description = "Descrição do evento",
            Format = "string"
            )]
        public string Description { get; set; }

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
        public DateTime Ocurrence { get; set; }

        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente associado ao evento",
            Format = "long"
            )]
        public long ClientId { get; set; }

        [SwaggerSchema(
            Title = "Participantes do evento",
            Description = "Participantes que precisam estar no evento",
            Format = "List<NewEventAttendantInput>"
            )]
        public List<NewEventAttendantInput> EventAttendants { get; set; }
    }
}
