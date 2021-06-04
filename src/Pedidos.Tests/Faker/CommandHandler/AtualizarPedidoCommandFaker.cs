using Bogus;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Command.Commands.ItemPedido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Tests.Faker.CommandHandler
{
    public static class AtualizarPedidoCommandFaker
    {
        public static Faker<AtualizarPedidoCommand> AtualizarPedidoSucessoCommand() =>
           new Faker<AtualizarPedidoCommand>()
               .Rules((x, y) =>
               {
                   y.CodigoPedido = "1";
                   y.Itens = new List<ItemPedidoCommand>()
                   {
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 1",
                           PrecoUnitario = 100,
                           Quantidade = 1
                       },
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 2",
                           PrecoUnitario = 10,
                           Quantidade = 12
                       }
                   };
               });

        public static Faker<AtualizarPedidoCommand> AtualizarPedidoInvalidoCommand() =>
           new Faker<AtualizarPedidoCommand>()
               .Rules((x, y) =>
               {
                   y.CodigoPedido = "2";
               });

        public static Faker<AtualizarPedidoCommand> AtualizarPedidoInvalidoItensDuplicadosCommand() =>
           new Faker<AtualizarPedidoCommand>()
               .Rules((x, y) =>
               {
                   y.CodigoPedido = "3";
                   y.Itens = new List<ItemPedidoCommand>()
                   {
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 1",
                           PrecoUnitario = 100,
                           Quantidade = 1
                       },
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 1",
                           PrecoUnitario = 10,
                           Quantidade = 12
                       }
                   };
               });
    }
}
