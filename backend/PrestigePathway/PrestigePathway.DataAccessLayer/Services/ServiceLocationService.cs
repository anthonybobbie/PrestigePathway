using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class ServiceLocationService : IServiceLocationService
    {
        private readonly IServiceLocationRepository _serviceLocationRepository;

        public ServiceLocationService(IServiceLocationRepository serviceLocationRepository)
        {
            _serviceLocationRepository = serviceLocationRepository;
        }

        public async Task<IEnumerable<ServiceLocation>> GetAllAsync()
        {
            return await _serviceLocationRepository.GetAllServiceLocationsAsync();
        }

        public async Task<ServiceLocation> GetByIdAsync(int id)
        {
            return await _serviceLocationRepository.GetServiceLocationByIdAsync(id);
        }

        public async Task AddAsync(ServiceLocation serviceLocation)
        {
            await _serviceLocationRepository.AddServiceLocationAsync(serviceLocation);
        }

        public async Task UpdateAsync(ServiceLocation serviceLocation)
        {
            await _serviceLocationRepository.UpdateServiceLocationAsync(serviceLocation);
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceLocationRepository.DeleteServiceLocationAsync(id);
        }
    }
}