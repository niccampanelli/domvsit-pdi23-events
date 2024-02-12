using Application.Event.Boundaries.New;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class NewCommand : Command<NewOutput>
    {
        public NewInput Input { get; set; }

        public NewCommand(NewInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
