using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SocialServicesDbContext _context;

        public LocationRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}