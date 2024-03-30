using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.MarkedUnmarked
{
    public class MarkedUnmarkedOutput
    {
        [SwaggerSchema(
            Title = "Marcados",
            Description = "Eventos com o status de marcado no mês",
            Format = "int"
            )]
        public float Marked { get; set; }

        [SwaggerSchema(
            Title = "Desmarcados",
            Description = "Eventos com o status de desmarcado no mês",
            Format = "int"
            )]
        public float Unmarked { get; set; }

        [SwaggerSchema(
            Title = "Mês",
            Description = "Mês referente",
            Format = "DateTime"
            )]
        public DateTime Month { get; set; }
    }
}
