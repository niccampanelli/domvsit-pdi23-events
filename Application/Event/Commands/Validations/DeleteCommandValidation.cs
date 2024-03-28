using Application.Event.Boundaries.Delete;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class DeleteCommandValidation : AbstractValidator<DeleteInput>
    {
        public DeleteCommandValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O id do evento deve ser informado")
                .NotNull().WithMessage("O id do evento deve ser informado")
                .GreaterThan(0).WithMessage("O id do evento deve ser informado");
        }
    }
}
