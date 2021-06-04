using System.Collections.Generic;

namespace Pedidos.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
