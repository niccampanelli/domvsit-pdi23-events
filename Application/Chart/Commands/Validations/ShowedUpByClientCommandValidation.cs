using Application.Chart.Boundaries.ShowedUpByClient;
using FluentValidation;

namespace Application.Chart.Commands.Validations
{
    public class ShowedUpByClientCommandValidation : AbstractValidator<ShowedUpByClientInput>
    {
        public ShowedUpByClientCommandValidation()
        {
            RuleFor(i => i.Months)
                .GreaterThan(0).WithMessage("O período de meses deve ser maior que 0");
        }
    }
}
