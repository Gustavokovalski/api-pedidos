using MediatR;
using Pedidos.Domain.Command.Result;
using System.Collections.Generic;

namespace Pedidos.Domain.Query.Queries.ObterPedidos
{
    public sealed class ObterPedidosQuery : IRequest<ApplicationResult<IList<ObterPedidosQueryResponse>>>
    {
    }
}
