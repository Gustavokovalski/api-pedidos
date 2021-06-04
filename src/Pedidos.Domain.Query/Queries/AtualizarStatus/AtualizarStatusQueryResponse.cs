using Pedidos.Domain.Enums;
using System.Collections.Generic;

namespace Pedidos.Domain.Query.Queries.AtualizarStatus
{
    public class AtualizarStatusQueryResponse
    {
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
