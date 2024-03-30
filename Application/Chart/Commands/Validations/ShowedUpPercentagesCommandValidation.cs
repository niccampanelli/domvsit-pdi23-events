using Application.Chart.Boundaries.ShowedUpPercentages;
using FluentValidation;

namespace Application.Chart.Commands.Validations
{
    public class ShowedUpPercentagesCommandValidation : AbstractValidator<ShowedUpPercentagesInput>
    {
        public ShowedUpPercentagesCommandValidation()
        {
            RuleFor(i => i.Months)
                .GreaterThan(0).WithMessage("O período de meses deve ser maior que 0");
        }
    }
}
