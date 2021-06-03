using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces;
using Pedidos.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Pedidos.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected internal readonly DatabaseContext _context;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> Get()
        {
            return await _context.Set<TEntity>()
               .ToListAsync();
        }

        public async Task InserirAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task Deletar(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task AtualizarAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task InserirRangeAsync(IEnumerable<TEntity> entity)
        {
            await _context.Set<TEntity>().AddRangeAsync(entity);
            await SaveChangesAsync();
        }

        public async Task AtualizarRangeAsync(IEnumerable<TEntity> entity)
        {
             _context.Set<TEntity>().UpdateRange(entity);
            await SaveChangesAsync();
        }
        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
