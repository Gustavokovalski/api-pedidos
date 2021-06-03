using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        new Task<IList<Pedido>> Get();
        Task<Pedido> ObterPorCodigo(string codigo);
    }
}
