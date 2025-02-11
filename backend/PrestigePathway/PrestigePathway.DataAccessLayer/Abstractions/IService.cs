using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Abstractions
{
    public interface IService<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}

