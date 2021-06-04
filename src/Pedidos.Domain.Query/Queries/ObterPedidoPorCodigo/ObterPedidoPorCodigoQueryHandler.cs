using AutoMapper;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo
{
    public sealed class ObterPedidoPorCodigoQueryHandler : IRequestHandler<ObterPedidoPorCodigoQuery, ApplicationResult<ObterPedidoPorCodigoQueryResponse>>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;

        public ObterPedidoPorCodigoQueryHandler(
           IMapper mapper,
           IPedidoRepository repository
           )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApplicationResult<ObterPedidoPorCodigoQueryResponse>> Handle(ObterPedidoPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterPorCodigo(request.Codigo);
            var pedido = _mapper.Map<Models.Pedido, ObterPedidoPorCodigoQueryResponse>(result);

            return new ApplicationResult<ObterPedidoPorCodigoQueryResponse>(
                  success: true,
                  message: EDefaultResults.Success,
                  data: pedido);
        }
    }
}
