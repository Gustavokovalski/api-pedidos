using Bogus;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Command.Commands.ItemPedido;
using System.Collections.Generic;

namespace Pedidos.Tests.Faker.CommandHandler
{
    public static class CriarPedidoCommandFaker
    {
        public static Faker<CriarPedidoCommand> CriarPedidoCommand() =>
           new Faker<CriarPedidoCommand>()
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
                       }
                   };
               });

        public static Faker<CriarPedidoCommand> CriarPedidoInvalidoCommand() =>
          new Faker<CriarPedidoCommand>()
              .Rules((x, y) =>
              {
                  y.CodigoPedido = "";
                  y.Itens = new List<ItemPedidoCommand>()
                  {
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 1",
                           PrecoUnitario = 100,
                           Quantidade = 1
                       }
                  };
              });

        public static Faker<CriarPedidoCommand> CriarPedidoInvalidoDuplicadoCommand() =>
          new Faker<CriarPedidoCommand>()
              .Rules((x, y) =>
              {
                  y.CodigoPedido = "2";
                  y.Itens = new List<ItemPedidoCommand>()
                  {
                       new ItemPedidoCommand()
                       {
                           Descricao = "Item 1",
                           PrecoUnitario = 100,
                           Quantidade = 1
                       }
                  };
              });

        public static Faker<CriarPedidoCommand> CriarPedidoInvalidoItensDuplicadosCommand() =>
          new Faker<CriarPedidoCommand>()
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
                           PrecoUnitario = 150,
                           Quantidade = 2
                       }
                  };
              });
    }
}
