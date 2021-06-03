using AutoMapper;
using FluentValidation;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Command.Commands.CriarPedido
{
    public sealed class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, ApplicationResult<CriarPedidoCommandResponse>>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CriarPedidoCommand> _validator;

        public CriarPedidoCommandHandler(
           IMapper mapper,
           IPedidoRepository repository,
           IValidator<CriarPedidoCommand> validator
           )
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<ApplicationResult<CriarPedidoCommandResponse>> Handle(CriarPedidoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return new ApplicationResult<CriarPedidoCommandResponse>(
                    success: false,
                    message: Enums.EDefaultResults.ValidationErrors,
                    validationErrors: validationResult.Errors
                    );
            }

            var itensDuplicados = command.Itens.Count > command.Itens.Select(x=>x.Descricao.ToLower().Trim()).Distinct().Count();
            if (itensDuplicados)
            {
                return new ApplicationResult<CriarPedidoCommandResponse>(
                   success: false,
                   message: Enums.EDefaultResults.Duplicateitems
                   );
            }

            var pedidoDuplicado = await _repository.ObterPorCodigo(command.CodigoPedido) != null ? true : false;
            if (pedidoDuplicado)
            {
                return new ApplicationResult<CriarPedidoCommandResponse>(
                   success: false,
                   message: Enums.EDefaultResults.Duplicate
                   );
            }

            var entity = _mapper.Map<Pedido>(command);
            await _repository.InserirAsync(entity);

            return new ApplicationResult<CriarPedidoCommandResponse>(
                success: true,
                message: Enums.EDefaultResults.Success,
                data: _mapper.Map<CriarPedidoCommandResponse>(entity)
                );
        }
    }
}
