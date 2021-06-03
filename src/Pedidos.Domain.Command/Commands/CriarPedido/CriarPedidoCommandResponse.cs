using System.Collections.Generic;
using Pedidos.Domain.Models;

namespace Pedidos.Domain.Command.Commands.CriarPedido
{
    public class CriarPedidoCommandResponse
    {
        public string CodigoPedido { get; set; }
        public IList<Item> Itens { get; set; }
    }
}
