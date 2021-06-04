using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Command.Commands.DeletarPedido;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Query.Queries.AtualizarStatus;
using Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo;
using Pedidos.Domain.Query.Queries.ObterPedidos;
using Pedidos.Infrastructure.Data.Repositories;
using System.Collections.Generic;

namespace Pedidos.CrossCutting.IoC
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();

            services.AddTransient<IRequestHandler<CriarPedidoCommand, ApplicationResult<CriarPedidoCommandResponse>>, CriarPedidoCommandHandler>();
            services.AddTransient<IValidator<CriarPedidoCommand>, CriarPedidoCommandValidator>();

            services.AddTransient<IRequestHandler<AtualizarPedidoCommand, ApplicationResult<AtualizarPedidoCommandResponse>>, AtualizarPedidoCommandHandler>();
            services.AddTransient<IValidator<AtualizarPedidoCommand>, AtualizarPedidoCommandValidator>();

            services.AddTransient<IRequestHandler<ObterPedidosQuery, ApplicationResult<IList<ObterPedidosQueryResponse>>>, ObterPedidosQueryHandler>();
            services.AddTransient<IRequestHandler<ObterPedidoPorCodigoQuery, ApplicationResult<ObterPedidoPorCodigoQueryResponse>>, ObterPedidoPorCodigoQueryHandler>();

            services.AddTransient<IRequestHandler<AtualizarStatusQuery, ApplicationResult<AtualizarStatusQueryResponse>>, AtualizarStatusQueryHandler>();
            services.AddTransient<IValidator<AtualizarStatusQuery>, AtualizarStatusQueryValidator>();

            services.AddTransient<IRequestHandler<DeletarPedidoCommand, ApplicationResult>, DeletarPedidoCommandHandler>();
        }
    }
}
