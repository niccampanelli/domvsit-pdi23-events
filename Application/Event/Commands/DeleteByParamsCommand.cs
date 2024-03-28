using Application.Event.Boundaries.DeleteByParams;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class DeleteByParamsCommand : Command<DeleteByParamsOutput>
    {
        public DeleteByParamsInput Input { get; set; }

        public DeleteByParamsCommand(DeleteByParamsInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteByParamsCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
