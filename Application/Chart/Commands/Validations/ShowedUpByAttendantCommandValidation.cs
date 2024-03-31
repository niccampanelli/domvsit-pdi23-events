using Application.Chart.Boundaries.ShowedUpByAttendant;
using FluentValidation;

namespace Application.Chart.Commands.Validations
{
    public class ShowedUpByAttendantCommandValidation : AbstractValidator<ShowedUpByAttendantInput>
    {
        public ShowedUpByAttendantCommandValidation()
        {
            RuleFor(i => i.Months)
                .GreaterThan(0).WithMessage("O período de meses deve ser maior que 0");
            RuleFor(i => i.ClientId)
                .NotEmpty().WithMessage("Informe o cliente no qual deseja visualizar os dados")
                .NotNull().WithMessage("Informe o cliente no qual deseja visualizar os dados")
                .GreaterThan(0).WithMessage("Informe um client válido");
        }
    }
}
