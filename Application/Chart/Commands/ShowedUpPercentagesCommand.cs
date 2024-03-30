using Application.Chart.Boundaries.ShowedUpPercentages;
using Application.Chart.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Chart.Commands
{
    public class ShowedUpPercentagesCommand : Command<ShowedUpPercentagesOutput>
    {
        public ShowedUpPercentagesInput Input { get; set; }

        public ShowedUpPercentagesCommand(ShowedUpPercentagesInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new ShowedUpPercentagesCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
