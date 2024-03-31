using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.ShowedUpByAttendant
{
    [SwaggerSchema(Required = new string[] { "ClientId" })]
    public class ShowedUpByAttendantInput
    {
        [SwaggerSchema(
            Title = "Meses",
            Description = "Quantos meses atrás mostrar",
            Format = "int"
            )]
        public int? Months { get; set; }

        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente para obter os participantes",
            Format = "long"
            )]
        public long ClientId { get; set; }
    }
}
