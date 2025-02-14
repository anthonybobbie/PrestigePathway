namespace PrestigePathway.Data.Abstractions
{
    public interface IService<TEntity, TResponse>
        where TEntity : class

    {
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse> GetByIdAsync(int id);
        Task<TResponse> AddAsync(TEntity entity);
        Task<TResponse> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}

