using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions
{
    public interface IServiceLocationService
    {
        Task<IEnumerable<ServiceLocation>> GetAllServiceLocationsAsync();
        Task<ServiceLocation> GetServiceLocationByIdAsync(int id);
        Task AddServiceLocationAsync(ServiceLocation serviceLocation);
        Task UpdateServiceLocationAsync(ServiceLocation serviceLocation);
        Task DeleteServiceLocationAsync(int id);
    }
}