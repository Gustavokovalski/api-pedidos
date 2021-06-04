using Pedidos.Domain.Query.Queries.ItemPedido;
using System.Collections.Generic;

namespace Pedidos.Domain.Query.Queries.ObterPedidos
{
    public class ObterPedidosQueryResponse
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoQuery> Itens { get; set; }
    }
}
