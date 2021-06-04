using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using Pedidos.Infrastructure.Data.Context;

namespace Pedidos.Infrastructure.Data.Repositories
{
    public class PedidoItemRepository : BaseRepository<Item>, IPedidoItemRepository
    {
        public PedidoItemRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
