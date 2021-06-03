using AutoMapper;
using FluentValidation;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Command.Commands.AtualizarPedido
{
    public class AtualizarPedidoCommandHandler : IRequestHandler<AtualizarPedidoCommand, ApplicationResult<AtualizarPedidoCommandResponse>>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AtualizarPedidoCommand> _validator;

        public AtualizarPedidoCommandHandler(
           IMapper mapper,
           IPedidoRepository pedidoRepository,
           IPedidoItemRepository pedidoItemRepository,
           IValidator<AtualizarPedidoCommand> validator
           )
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
            _pedidoItemRepository = pedidoItemRepository;
            _validator = validator;
        }

        public async Task<ApplicationResult<AtualizarPedidoCommandResponse>> Handle(AtualizarPedidoCommand command, CancellationToken cancellationToken)
        {

            var pedido = await _pedidoRepository.ObterPorCodigo(command.CodigoPedido);
            var pedidoExiste = pedido != null ? true : false;

            if (!pedidoExiste)
            {
                return new ApplicationResult<AtualizarPedidoCommandResponse>(
                    success: false,
                    message: Enums.EDefaultResults.NotFound,
                    data: null
                );
            }

            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return new ApplicationResult<AtualizarPedidoCommandResponse>(
                    success: false,
                    message: Enums.EDefaultResults.ValidationErrors,
                    validationErrors: validationResult.Errors
                    );
            }

            var itensDuplicados = command.Itens.Count > command.Itens.Select(x => x.Descricao.ToLower().Trim()).Distinct().Count();
            if (itensDuplicados)
            {
                return new ApplicationResult<AtualizarPedidoCommandResponse>(
                   success: false,
                   message: Enums.EDefaultResults.Duplicateitems
                   );
            }

            await AtualizarItensPedido(command, pedido);
            await InserirItensPedido(command, pedido);

            return new ApplicationResult<AtualizarPedidoCommandResponse>(
                success: true,
                message: Enums.EDefaultResults.SuccessEdit
                );
        }

        private async Task AtualizarItensPedido(AtualizarPedidoCommand command, Pedido pedido)
        {
            var itensCommandUpdate = command.Itens.Where(l2 => pedido.Itens.Any(l1 => l1.Descricao.ToLower().Trim() == l2.Descricao.ToLower().Trim()));
            var itensUpdate = _mapper.Map<IList<Item>>(itensCommandUpdate);
            if (itensUpdate.Count > 0)
            {
                itensUpdate.ToList().ForEach(x => { x.PedidoId = pedido.Id; x.Id = pedido.Itens.Where(z => z.Descricao.ToLower().Trim() == x.Descricao.ToLower().Trim()).Select(y => y.Id).FirstOrDefault(); });
                await _pedidoItemRepository.AtualizarRangeAsync(itensUpdate);
            }
        }

        private async Task InserirItensPedido(AtualizarPedidoCommand command, Pedido pedido)
        {
            var itensCommandInsercao = command.Itens.Where(l2 => !pedido.Itens.Any(l1 => l1.Descricao.ToLower().Trim() == l2.Descricao.ToLower().Trim()));
            var itensInsercao = _mapper.Map<IList<Item>>(itensCommandInsercao);
            if (itensInsercao.Count > 0)
            {
                itensInsercao.ToList().ForEach(x => x.PedidoId = pedido.Id);
                await _pedidoItemRepository.InserirRangeAsync(itensInsercao);
            }
        }
    }
}
