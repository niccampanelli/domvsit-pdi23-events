using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.DeleteByParams
{
    public class DeleteByParamsInput
    {
        [SwaggerSchema(
            Title = "Id do cliente",
            Description = "Id do cliente associado ao evento para deletar",
            Format = "long"
            )]
        public long? ClientId { get; set; }
    }
}
