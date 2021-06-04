using MediatR;
using Pedidos.Domain.Command.Result;

namespace Pedidos.Domain.Command.Commands.DeletarPedido
{
    public class DeletarPedidoCommand : IRequest<ApplicationResult>
    {
        public string Codigo { get; set; }
        public DeletarPedidoCommand(string codigo)
        {
            Codigo = codigo;
        }
    }
}
