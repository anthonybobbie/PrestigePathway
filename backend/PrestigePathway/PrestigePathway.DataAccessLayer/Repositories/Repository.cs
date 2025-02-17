using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity 
    {
        private readonly SocialServicesDbContext _context;

        public Repository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public  IQueryable<TEntity> Query()
        {
            return  _context.Set<TEntity>();
        }
    }
}