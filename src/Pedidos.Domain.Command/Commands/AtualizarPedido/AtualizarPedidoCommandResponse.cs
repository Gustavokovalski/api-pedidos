using Pedidos.Domain.Models;
using System.Collections.Generic;

namespace Pedidos.Domain.Command.Commands.AtualizarPedido
{
    public class AtualizarPedidoCommandResponse
    {
        public string CodigoPedido { get; set; }
        public IList<Item> Itens { get; set; }
    }
}
