using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class LocationService : IService<Location>
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _locationRepository.GetAllLocationsAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _locationRepository.GetLocationByIdAsync(id);
        }

        public async Task AddAsync(Location location)
        {
            await _locationRepository.AddLocationAsync(location);
        }

        public async Task UpdateAsync(Location location)
        {
            await _locationRepository.UpdateLocationAsync(location);
        }

        public async Task DeleteAsync(int id)
        {
            await _locationRepository.DeleteLocationAsync(id);
        }
    }
}