using Application.Chart.Boundaries.ShowedUpByAttendant;
using Application.Chart.Commands.Validations;
using Domain.Base.Messages;

namespace Application.Chart.Commands
{
    public class ShowedUpByAttendantCommand : Command<List<ShowedUpByAttendantOutput>>
    {
        public ShowedUpByAttendantInput Input { get; set; }

        public ShowedUpByAttendantCommand(ShowedUpByAttendantInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new ShowedUpByAttendantCommandValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
