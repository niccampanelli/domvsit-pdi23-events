using Application.Boundaries.Commom;
using Application.Event.Boundaries.List;
using Application.Event.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Event.Commands
{
    public class ListCommand : Command<PaginatedResponse<ListOutput>>
    {
        public ListInput Input { get; set; }

        public ListCommand(ListInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new ListCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
