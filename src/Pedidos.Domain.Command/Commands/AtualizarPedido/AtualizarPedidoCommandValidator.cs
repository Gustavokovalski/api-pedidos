using FluentValidation;

namespace Pedidos.Domain.Command.Commands.AtualizarPedido
{
    public class AtualizarPedidoCommandValidator : AbstractValidator<AtualizarPedidoCommand>
    {
        public AtualizarPedidoCommandValidator()
        {
            RuleFor(c => c.CodigoPedido)
                .NotNull()
                .NotEmpty()
                .WithMessage("Código do pedido é obrigatorio");

            RuleFor(c => c.Itens)
               .NotNull()
               .NotEmpty()
               .WithMessage("É obrigatório inserir ao menos um item");
        }
    }
}
