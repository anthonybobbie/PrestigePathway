using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetServiceByIdAsync(id);
        }

        public async Task AddAsync(Service service)
        {
            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateAsync(Service service)
        {
            await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
