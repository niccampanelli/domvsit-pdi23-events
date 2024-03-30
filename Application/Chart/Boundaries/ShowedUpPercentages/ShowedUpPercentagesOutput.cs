using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.ShowedUpPercentages
{
    public class ShowedUpPercentagesOutput
    {
        [SwaggerSchema(
            Title = "Porcentagem de comparecimento",
            Description = "Porcentagem de comparecimento de todos participantes de todos os eventos",
            Format = "float"
            )]
        public float ShowedUpPercentage { get; set; }
    }
}
