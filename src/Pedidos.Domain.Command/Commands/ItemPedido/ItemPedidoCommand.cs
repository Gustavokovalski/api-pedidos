namespace Pedidos.Domain.Command.Commands.ItemPedido
{
    public class ItemPedidoCommand
    {
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
