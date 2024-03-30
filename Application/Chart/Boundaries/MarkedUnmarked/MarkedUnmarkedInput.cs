using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.MarkedUnmarked
{
    public class MarkedUnmarkedInput
    {
        [SwaggerSchema(
            Title = "Meses",
            Description = "Quantos meses atrás mostrar",
            Format = "int"
            )]
        public int? Months { get; set; }
    }
}
