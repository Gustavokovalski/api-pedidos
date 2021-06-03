using AutoMapper;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Command.Commands.DeletarPedido
{
    public class DeletarPedidoCommandHandler : IRequestHandler<DeletarPedidoCommand, ApplicationResult>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;

        public DeletarPedidoCommandHandler(
           IMapper mapper,
           IPedidoRepository repository
           )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApplicationResult> Handle(DeletarPedidoCommand command, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorCodigo(command.Codigo);
            var pedidoExiste = pedido != null ? true : false;

            if (!pedidoExiste)
            {
                return new ApplicationResult(
                    success: false,
                    message: Enums.EDefaultResults.NotFound
                );
            }

            await _repository.Deletar(pedido);

            return new ApplicationResult(
               success: true,
               message: Enums.EDefaultResults.Success
           );
        }
    }
}
