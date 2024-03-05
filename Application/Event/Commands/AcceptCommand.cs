using Application.Event.Boundaries.Accept;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class AcceptCommand : Command<AcceptOutput>
    {
        public AcceptInput Input { get; set; }

        public AcceptCommand(AcceptInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new AcceptCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
