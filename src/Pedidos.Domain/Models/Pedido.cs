using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public ICollection<Item> Itens { get; set; }

        //public List<string> ObterStatus(int itensAprovados, decimal valorAprovado, EStatusPedido statusPedido)
        //{
        //    var listaStatus = new List<string>();
        //    if (String.IsNullOrEmpty(CodigoPedido))
        //        listaStatus.Add(EStatusPedido.CodigoPedidoInvalido.GetEnumDescription());
        //    else
        //    {
        //        if (statusPedido == EStatusPedido.Reprovado) listaStatus.Add(EStatusPedido.Reprovado.GetEnumDescription());

        //        if (statusPedido == EStatusPedido.Aprovado) {
        //            var somaQuantidadeItens = Itens.ToList().Sum(x => x.Quantidade);
        //            var somaValorItens = Itens.ToList().Sum(x => x.PrecoUnitario);

        //            if(valorAprovado != somaValorItens) listaStatus.Add(valorAprovado < somaValorItens ? EStatusPedido.AprovadoValorMenor.GetEnumDescription() : EStatusPedido.AprovadoValorMaior.GetEnumDescription());
        //            if(itensAprovados != somaQuantidadeItens) listaStatus.Add(itensAprovados < somaQuantidadeItens ? EStatusPedido.AprovadoQuantidadeMenor.GetEnumDescription() : EStatusPedido.AprovadoQuantidadeMaior.GetEnumDescription());
        //            if(valorAprovado == somaValorItens && itensAprovados == somaQuantidadeItens) listaStatus.Add(EStatusPedido.Aprovado.GetEnumDescription());
        //        }
        //    }

        //    return listaStatus;
        //}
    }
}
