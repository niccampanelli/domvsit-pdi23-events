using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.List
{
    public class ListOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do evento",
            Format = "long"
            )]
        public long Id { get; set; }

        [SwaggerSchema(
            Title = "Título",
            Description = "Título do evento",
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
            Description = "Tags que descrevem o evento",
            Format = "List<string>"
            )]
        public List<string>? Tags { get; set; }

        [SwaggerSchema(
            Title = "Link",
            Description = "Link onde o evento ocorrerá",
            Format = "string"
            )]
        public string? Link { get; set; }

        [SwaggerSchema(
            Title = "Id do usuário",
            Description = "Id do consultor responsável pelo evento",
            Format = "long"
            )]
        public long ConsultorId { get; set; }

        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente associado ao evento",
            Format = "long"
            )]
        public long ClientId { get; set; }

        [SwaggerSchema(
            Title = "Ocorrência",
            Description = "Data da ocorrência do evento",
            Format = "DateTime"
            )]
        public DateTime Ocurrence { get; set; }

        [SwaggerSchema(
            Title = "Criado em",
            Description = "Data na qual o evento foi criado",
            Format = "DateTime"
            )]
        public DateTime CreatedAt { get; set; }

        [SwaggerSchema(
            Title = "Atualizado em",
            Description = "Data na qual o evento foi atualizado",
            Format = "DateTime"
            )]
        public DateTime UpdatedAt { get; set; }

        [SwaggerSchema(
            Title = "Status",
            Description = "Se o evento está marcado ou foi desmarcado",
            Format = "bool"
            )]
        public bool Status { get; set; }

        [SwaggerSchema(
            Title = "Participantes",
            Description = "Participantes que precisam estar no evento",
            Format = "List<EventAttendantDto>"
            )]
        public List<ListEventAttendantOutput> EventAttendants { get; set; }
    }
}
