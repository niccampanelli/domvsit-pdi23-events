using Swashbuckle.AspNetCore.Annotations;

namespace Application.Boundaries.Commom
{
    public class PaginatedResponse<T>
    {
        [SwaggerSchema(
            Title = "Pagina atual",
            Description = "Número da página dessa resposta",
            Format = "int"
            )]
        public int CurrentPage { get; set; }

        [SwaggerSchema(
            Title = "Quantidade de itens",
            Description = "Quantidade de itens na página atual",
            Format = "int"
            )]
        public int ItemsCount { get; set; }

        [SwaggerSchema(
            Title = "Resposta",
            Description = "Resposta dessa página",
            Format = "List<generic>"
            )]
        public List<T> Data { get; set; }

        [SwaggerSchema(
            Title = "Total",
            Description = "Quantidade total de itens existentes",
            Format = "long"
            )]
        public long Total { get; set; }
    }
}
