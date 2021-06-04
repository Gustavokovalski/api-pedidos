using AutoMapper;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Query.Queries.ObterPedidos
{
    public sealed class ObterPedidosQueryHandler : IRequestHandler<ObterPedidosQuery, ApplicationResult<IList<ObterPedidosQueryResponse>>>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;

        public ObterPedidosQueryHandler(
           IMapper mapper,
           IPedidoRepository repository
           )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApplicationResult<IList<ObterPedidosQueryResponse>>> Handle(ObterPedidosQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Get();
            var pedidos = _mapper.Map<IList<Models.Pedido>, IList<ObterPedidosQueryResponse>>(result);

            return new ApplicationResult<IList<ObterPedidosQueryResponse>>(
                  success: true,
                  message: EDefaultResults.Success,
                  data: pedidos);
        }
    }
}
