using Application.Event.Boundaries.List;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class ListCommandValidation : AbstractValidator<ListInput>
    {
        public ListCommandValidation()
        {
            RuleFor(i => i.Page)
                .GreaterThan(0);
            RuleFor(i => i.Limit)
                .GreaterThan(0);
        }
    }
}
