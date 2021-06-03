using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task InserirAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task InserirRangeAsync(IEnumerable<TEntity> entity);
        Task AtualizarRangeAsync(IEnumerable<TEntity> entity);
        Task<IList<TEntity>> Get();
        Task Deletar(TEntity entity);
    }
}
