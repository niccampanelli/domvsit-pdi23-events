using Application.Event.Boundaries.List;
using FluentValidation;

namespace Application.Event.Commands.Validations
{
    public class ListCommandValidation : AbstractValidator<ListInput>
    {
        public ListCommandValidation()
        {
            RuleFor(i => i.Page)
                .GreaterThan(0).WithMessage("A página deve ser maior que zero");
            RuleFor(i => i.Limit)
                .GreaterThan(0).WithMessage("A quantidade de itens por página deve ser maior que zero");
            RuleFor(i => i.SortOrder)
                .Must(order => order != null ? (new string[] { "ASC", "DESC" }.Contains(order)) : true).WithMessage("A ordem deve ser ou descendente ou ascendente");
            RuleFor(i => i.SortField)
                .Must(field => field != null ? (new string[] { "title", "ocurrence", "createdAt", "updatedAt" }.Contains(field)) : true).WithMessage("Campo de ordenação inválido");
        }
    }
}
