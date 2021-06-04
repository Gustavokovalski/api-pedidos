using Bogus;
using Pedidos.Domain.Query.Queries.AtualizarStatus;

namespace Pedidos.Tests.Faker.QueryHandler
{
    public static class AtualizarStatusQueryFaker
    {
        public static Faker<AtualizarStatusQuery> AtualizarStatusInvalido() =>
           new Faker<AtualizarStatusQuery>()
               .Rules((x, y) =>
               {
                   y.Status = "lorem ipsum";
               });

        public static Faker<AtualizarStatusQuery> AtualizarStatusAprovado() =>
          new Faker<AtualizarStatusQuery>()
              .Rules((x, y) =>
              {
                  y.Status = "APROVADO";
                  y.Pedido = "1";
                  y.ItensAprovados = 5;
                  y.ValorAprovado = 10;
              });

        public static Faker<AtualizarStatusQuery> AtualizarStatusReprovado() =>
       new Faker<AtualizarStatusQuery>()
           .Rules((x, y) =>
           {
               y.Status = "REPROVADO";
               y.Pedido = "1";
               y.ItensAprovados = 5;
               y.ValorAprovado = 10;
           });
    }
}
