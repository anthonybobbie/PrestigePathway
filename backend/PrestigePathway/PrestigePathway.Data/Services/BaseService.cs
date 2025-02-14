using Mapster;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.Data.Services
{
    public class BaseService<TEntity, TResponse> : IService<TEntity, TResponse> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TResponse> AddAsync(TEntity entity)
        {
            var addedEntity = await _repository.AddAsync(entity);
            return addedEntity.Adapt<TResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public async Task<TResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? default : entity.Adapt<TResponse>();
        }

        public async Task<TResponse> UpdateAsync(TEntity entity)
        {
            var updatedEntity = await _repository.UpdateAsync(entity);
            return updatedEntity.Adapt<TResponse>();
        }
    }
}
