using Pedidos.Domain.Query.Queries.ItemPedido;
using System.Collections.Generic;

namespace Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo
{
    public class ObterPedidoPorCodigoQueryResponse
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoQuery> Itens { get; set; }
    }
}
