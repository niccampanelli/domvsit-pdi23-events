using Application.Event.Boundaries.Accept;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class AcceptCommandValidation : AbstractValidator<AcceptInput>
    {
        public AcceptCommandValidation()
        {
            RuleFor(i => i.EventId)
                .NotNull().WithMessage("O id do evento deve ser informado")
                .NotEmpty().WithMessage("O id do evento deve ser informado")
                .GreaterThan(1).WithMessage("O id do evento é inválido");
            RuleFor(i => i.AttendantId)
                .NotNull().WithMessage("O id do participante deve ser informado")
                .NotEmpty().WithMessage("O id do participante deve ser informado")
                .GreaterThan(1).WithMessage("O id do participante é inválido");
        }
    }
}
