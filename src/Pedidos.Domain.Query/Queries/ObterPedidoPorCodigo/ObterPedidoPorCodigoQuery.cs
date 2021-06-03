using MediatR;
using Pedidos.Domain.Command.Result;

namespace Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo
{
    public class ObterPedidoPorCodigoQuery : IRequest<ApplicationResult<ObterPedidoPorCodigoQueryResponse>>
    {
        public string Codigo { get; set; }
        public ObterPedidoPorCodigoQuery(string codigo)
        {
            Codigo = codigo;
        }
    }
}
