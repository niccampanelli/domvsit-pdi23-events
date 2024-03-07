using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.ShowUp
{
    public class ShowUpControllerInput
    {
        [SwaggerSchema(
            Title = "Compareceu",
            Description = "O participante compareceu ao evento?",
            Format = "bool"
            )]
        public bool? ShowedUp { get; set; }

        public long AttendantId { get; set; }
    }
}
