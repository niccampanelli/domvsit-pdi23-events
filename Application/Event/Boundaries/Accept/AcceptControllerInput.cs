using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.Accept
{
    public class AcceptControllerInput
    {
        [SwaggerSchema(
            Title = "Aceitou",
            Description = "O participante aceitou o evento?",
            Format = "bool"
            )]
        public bool? Accepted { get; set; }

        public long AttendantId { get; set; }
    }
}
