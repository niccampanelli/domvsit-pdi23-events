using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.New
{
    public class NewOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do evento criado",
            Format = "long"
            )]
        public long CreatedId { get; set; }
    }
}
