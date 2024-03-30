using Application.Chart.Boundaries.MarkedUnmarked;
using Application.Chart.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Chart.Commands
{
    public class MarkedUnmarkedCommand : Command<List<MarkedUnmarkedOutput>>
    {
        public MarkedUnmarkedInput Input { get; set; }

        public MarkedUnmarkedCommand(MarkedUnmarkedInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new MarkedUnmarkedCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
