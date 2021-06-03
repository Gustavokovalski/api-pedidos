using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces;
using Pedidos.Domain.Models;
using Pedidos.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Infrastructure.Data.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DatabaseContext context) : base(context)
        {

        }

        public new async Task<IList<Pedido>> Get()
        {
            return await _context.Pedidos.Include(x=>x.Itens).ToListAsync();
        } 

        public async Task<Pedido> ObterPorCodigo(string codigo)
        {
            return await _context.Pedidos.Include(x=>x.Itens).AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPedido.ToLower() == codigo.ToLower());
        }
    }
}
