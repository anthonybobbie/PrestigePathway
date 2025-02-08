using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class ServiceLocationRepository : IServiceLocationRepository
    {
        private readonly SocialServicesDbContext _context;

        public ServiceLocationRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceLocation>> GetAllServiceLocationsAsync()
        {
            return await _context.ServiceLocations
                .Include(sl => sl.Service) // Include related Service data
                .Include(sl => sl.Location) // Include related Location data
                .ToListAsync();
        }

        public async Task<ServiceLocation> GetServiceLocationByIdAsync(int id)
        {
            return await _context.ServiceLocations
                .Include(sl => sl.Service) // Include related Service data
                .Include(sl => sl.Location) // Include related Location data
                .FirstOrDefaultAsync(sl => sl.ID == id);
        }

        public async Task AddServiceLocationAsync(ServiceLocation serviceLocation)
        {
            _context.ServiceLocations.Add(serviceLocation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceLocationAsync(ServiceLocation serviceLocation)
        {
            _context.Entry(serviceLocation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceLocationAsync(int id)
        {
            var serviceLocation = await _context.ServiceLocations.FindAsync(id);
            if (serviceLocation != null)
            {
                _context.ServiceLocations.Remove(serviceLocation);
                await _context.SaveChangesAsync();
            }
        }
    }
}