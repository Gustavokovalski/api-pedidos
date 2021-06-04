using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Enums;

namespace Pedidos.Domain.Query.Queries.AtualizarStatus
{
    public class AtualizarStatusQuery : IRequest<ApplicationResult<AtualizarStatusQueryResponse>>
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
