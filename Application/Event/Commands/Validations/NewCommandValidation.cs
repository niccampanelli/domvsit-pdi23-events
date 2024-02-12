using Application.Event.Boundaries.New;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class NewCommandValidation : AbstractValidator<NewInput>
    {
        public NewCommandValidation()
        {
            RuleFor(i => i.Title)
                .NotEmpty().WithMessage("O título do evento deve ser informada")
                .NotNull().WithMessage("O título do evento deve ser informado");
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("A descrição do evento deve ser informada")
                .NotNull().WithMessage("A descrição do evento deve ser informada");
            RuleFor(i => i.Ocurrence)
                .NotEmpty().WithMessage("A data de ocorrência do evento deve ser informada")
                .NotNull().WithMessage("A data de ocorrência do evento deve ser informada")
                .GreaterThan(DateTime.UtcNow).WithMessage("A data de ocorrência do evento deve ser uma data futura");
            RuleFor(i => i.ConsultorId)
                .NotEmpty().WithMessage("O id do usuário não foi informado")
                .NotNull().WithMessage("A id do usuário não foi informado");
        }
    }
}
