using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.ShowedUpByClient
{
    public class ShowedUpByClientOutput
    {
        [SwaggerSchema(
            Title = "Quantidade de eventos",
            Description = "Quantidade de eventos nos quais o cliente não compareceu",
            Format = "int"
            )]
        public int EventCount { get; set; }

        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente",
            Format = "long"
            )]
        public long ClientId { get; set; }
    }
}
