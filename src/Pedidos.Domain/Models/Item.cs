﻿namespace Pedidos.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
