using Swashbuckle.AspNetCore.Annotations;

namespace Application.Chart.Boundaries.ShowedUpByAttendant
{
    public class ShowedUpByAttendantOutput
    {
        [SwaggerSchema(
            Title = "Quantidade de eventos",
            Description = "Quantidade de eventos nos quais o cliente não compareceu",
            Format = "int"
            )]
        public int EventCount { get; set; }

        [SwaggerSchema(
            Title = "Id do participante",
            Description = "Id do participante",
            Format = "long"
            )]
        public long AttendantId { get; set; }
    }
}
