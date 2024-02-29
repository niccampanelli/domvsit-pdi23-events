using Application.Event.Boundaries.Update;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class UpdateCommand : Command<UpdateOutput>
    {
        public UpdateInput Input { get; set; }

        public UpdateCommand(UpdateInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
