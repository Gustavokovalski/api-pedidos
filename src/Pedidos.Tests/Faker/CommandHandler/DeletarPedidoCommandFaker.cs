using Bogus;
using Pedidos.Domain.Command.Commands.DeletarPedido;

namespace Pedidos.Tests.Faker.CommandHandler
{
    public static class DeletarPedidoCommandFaker
    {
        public static Faker<DeletarPedidoCommand> DeletarPedidoComSucessoCommand() =>
           new Faker<DeletarPedidoCommand>()
               .Rules((x, y) =>
               {
                   new DeletarPedidoCommand("1234");
               });
    }
}
