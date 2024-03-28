using Application.Event.Boundaries.Delete;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class DeleteCommand : Command<DeleteOutput>
    {
        public DeleteInput Input { get; set; }

        public DeleteCommand(DeleteInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
