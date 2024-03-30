using Application.Chart.Boundaries.MarkedUnmarked;
using FluentValidation;

namespace Application.Chart.Commands.Validations
{
    public class MarkedUnmarkedCommandValidation : AbstractValidator<MarkedUnmarkedInput>
    {
        public MarkedUnmarkedCommandValidation()
        {
            RuleFor(i => i.Months)
                .GreaterThan(0).WithMessage("O período de meses deve ser maior que 0");
        }
    }
}
