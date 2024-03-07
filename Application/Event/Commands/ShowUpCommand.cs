using Application.Event.Boundaries.ShowUp;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class ShowUpCommand : Command<ShowUpOutput>
    {
        public ShowUpInput Input { get; set; }

        public ShowUpCommand(ShowUpInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new ShowUpCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
