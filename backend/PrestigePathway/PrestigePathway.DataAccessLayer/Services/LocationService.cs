using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllLocationsAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetLocationByIdAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            await _locationRepository.AddLocationAsync(location);
        }

        public async Task UpdateLocationAsync(Location location)
        {
            await _locationRepository.UpdateLocationAsync(location);
        }

        public async Task DeleteLocationAsync(int id)
        {
            await _locationRepository.DeleteLocationAsync(id);
        }
    }
}