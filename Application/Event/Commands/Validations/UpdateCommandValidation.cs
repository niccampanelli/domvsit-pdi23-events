using Application.Event.Boundaries.Update;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class UpdateCommandValidation : AbstractValidator<UpdateInput>
    {
        public UpdateCommandValidation()
        {
            RuleFor(i => i.Ocurrence)
                .GreaterThan(DateTime.UtcNow).WithMessage("A data de ocorrência do evento deve ser uma data futura");
        }
    }
}
