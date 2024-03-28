using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.Delete
{
    [SwaggerSchema(Required = new string[] { "Id" })]
    public class DeleteInput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do evento",
            Format = "long"
            )]
        public long Id { get; set; }
    }
}
