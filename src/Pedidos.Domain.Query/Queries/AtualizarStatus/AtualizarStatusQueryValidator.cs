using FluentValidation;
using Pedidos.Domain.Extensions;

namespace Pedidos.Domain.Query.Queries.AtualizarStatus
{
    public class AtualizarStatusQueryValidator : AbstractValidator<AtualizarStatusQuery>
    {
        public AtualizarStatusQueryValidator()
        {
            RuleFor(c => c.Status)
               .Must(x => x.ToUpper().Trim().Equals(Enums.EStatusPedido.Aprovado.GetEnumDescription()) 
               || x.ToUpper().Trim().Equals(Enums.EStatusPedido.Reprovado.GetEnumDescription()))
               .WithMessage("O status do pedido deve ser APROVADO ou REPROVADO.");
        }
    }
}
