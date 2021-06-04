using MediatR;
using Pedidos.Domain.Command.Commands.ItemPedido;
using Pedidos.Domain.Command.Result;
using System.Collections.Generic;

namespace Pedidos.Domain.Command.Commands.CriarPedido
{
    public sealed class CriarPedidoCommand : IRequest<ApplicationResult<CriarPedidoCommandResponse>>
    {
        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoCommand> Itens { get; set; }
    }
}
