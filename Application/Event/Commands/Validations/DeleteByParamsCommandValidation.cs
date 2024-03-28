using Application.Event.Boundaries.DeleteByParams;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class DeleteByParamsCommandValidation : AbstractValidator<DeleteByParamsInput>
    {
        public DeleteByParamsCommandValidation()
        {
            RuleFor(i => i.ClientId)
                .GreaterThan(0).WithMessage("O id do cliente deve ser maior que zero");
        }
    }
}
