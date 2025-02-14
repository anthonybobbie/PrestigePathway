using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity TEntity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity TEntity);
        IQueryable<TEntity> Query();
    }
}