using Application.Boundaries.Commom;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.List
{
    public class ListInput : IPaginationRequest, ISortingRequest
    {
        [SwaggerSchema(
            Title = "Página",
            Description = "Página a ser listada",
            Format = "int"
            )]
        public int? Page { get; set; }

        [SwaggerSchema(
            Title = "Limite",
            Description = "Limite de itens na página",
            Format = "int"
            )]
        public int? Limit { get; set; }

        [SwaggerSchema(
            Title = "Campo",
            Description = "Campo para ordenar",
            Format = "string"
            )]
        public string? SortField { get; set; }

        [SwaggerSchema(
            Title = "Ordem",
            Description = "Direção da ordenação (asc, desc)",
            Format = "string"
            )]
        public string? SortOrder { get; set; }

        [SwaggerSchema(
            Title = "Id do usuário",
            Description = "Id do consultor responsável pelo evento",
            Format = "long"
            )]
        public long? ConsultorId { get; set; }

        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente associado ao evento",
            Format = "long"
            )]
        public long? ClientId { get; set; }

        [SwaggerSchema(
            Title = "Data mínima",
            Description = "Data mínima de ocorrência do evento",
            Format = "DateTime"
            )]
        public DateTime? OcurrenceMin { get; set; }

        [SwaggerSchema(
            Title = "Data máxima",
            Description = "Data máxima de ocorrência do evento",
            Format = "DateTime"
            )]
        public DateTime? OcurrenceMax { get; set; }

        [SwaggerSchema(
            Title = "Pesquisa",
            Description = "Texto de pesquisa para procurar entre os atributos do evento",
            Format = "string"
            )]
        public string? Search { get; set; }
    }
}
