using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IServiceLocationRepository
    {
        Task<IEnumerable<ServiceLocation>> GetAllServiceLocationsAsync();
        Task<ServiceLocation> GetServiceLocationByIdAsync(int id);
        Task AddServiceLocationAsync(ServiceLocation serviceLocation);
        Task UpdateServiceLocationAsync(ServiceLocation serviceLocation);
        Task DeleteServiceLocationAsync(int id);
    }
}