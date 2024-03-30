using Application.Chart.Boundaries.ShowedUpByClient;
using Application.Chart.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Chart.Commands
{
    public class ShowedUpByClientCommand : Command<List<ShowedUpByClientOutput>>
    {
        public ShowedUpByClientInput Input { get; set; }

        public ShowedUpByClientCommand(ShowedUpByClientInput input)
        {
            Input = input;   
        }

        public override bool IsValid()
        {
            ValidationResult = new ShowedUpByClientCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
