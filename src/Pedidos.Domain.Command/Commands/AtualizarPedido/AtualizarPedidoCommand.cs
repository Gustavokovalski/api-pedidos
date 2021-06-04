using MediatR;
using Pedidos.Domain.Command.Commands.ItemPedido;
using Pedidos.Domain.Command.Result;
using System.Collections.Generic;

namespace Pedidos.Domain.Command.Commands.AtualizarPedido
{
    public class AtualizarPedidoCommand : IRequest<ApplicationResult<AtualizarPedidoCommandResponse>>
    {
        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoCommand> Itens { get; set; }
    }
}
