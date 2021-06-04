namespace Pedidos.Domain.Query.Queries.ItemPedido
{
    public class ItemPedidoQuery
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
