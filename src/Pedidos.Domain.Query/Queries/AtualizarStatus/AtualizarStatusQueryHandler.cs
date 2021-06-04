using FluentValidation;
using MediatR;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Extensions;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Domain.Query.Queries.AtualizarStatus
{
    public sealed class AtualizarStatusQueryHandler : IRequestHandler<AtualizarStatusQuery, ApplicationResult<AtualizarStatusQueryResponse>>
    {
        private readonly IPedidoRepository _repository;
        private readonly IValidator<AtualizarStatusQuery> _validator;

        public AtualizarStatusQueryHandler(
           IPedidoRepository repository,
           IValidator<AtualizarStatusQuery> validator
           )
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ApplicationResult<AtualizarStatusQueryResponse>> Handle(AtualizarStatusQuery request, CancellationToken cancellationToken)
        {
                var validationResult = await _validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    return new ApplicationResult<AtualizarStatusQueryResponse>(
                        success: false,
                        message: Enums.EDefaultResults.ValidationErrors,
                        validationErrors: validationResult.Errors
                        );
                }


                EStatusPedido enumStatus = (EStatusPedido)Enum.Parse(typeof(EStatusPedido), request.Status, true);
                var result = await _repository.ObterPorCodigo(request.Pedido);

                var response = new AtualizarStatusQueryResponse()
                {
                    Pedido = request.Pedido,
                    Status = ObterStatus(result, request.ItensAprovados, request.ValorAprovado, enumStatus)
                };

                return new ApplicationResult<AtualizarStatusQueryResponse>(true, EDefaultResults.Success, response);
        }

        private List<string> ObterStatus(Pedido pedido, int itensAprovados, decimal valorAprovado, EStatusPedido statusPedido)
        {
            var listaStatus = new List<string>();
            if (pedido == null)
                listaStatus.Add(EStatusPedido.CodigoPedidoInvalido.GetEnumDescription());
            else
            {
                if (statusPedido == EStatusPedido.Reprovado) listaStatus.Add(EStatusPedido.Reprovado.GetEnumDescription());

                if (statusPedido == EStatusPedido.Aprovado)
                {
                    var somaQuantidadeItens = pedido.Itens.ToList().Sum(x => x.Quantidade);
                    var somaValorItens = pedido.Itens.ToList().Sum(x => x.PrecoUnitario);

                    if (valorAprovado != somaValorItens) listaStatus.Add(valorAprovado < somaValorItens ? EStatusPedido.AprovadoValorMenor.GetEnumDescription() : EStatusPedido.AprovadoValorMaior.GetEnumDescription());
                    if (itensAprovados != somaQuantidadeItens) listaStatus.Add(itensAprovados < somaQuantidadeItens ? EStatusPedido.AprovadoQuantidadeMenor.GetEnumDescription() : EStatusPedido.AprovadoQuantidadeMaior.GetEnumDescription());
                    if (valorAprovado == somaValorItens && itensAprovados == somaQuantidadeItens) listaStatus.Add(EStatusPedido.Aprovado.GetEnumDescription());
                }
            }

            return listaStatus;
        }
    }
}
