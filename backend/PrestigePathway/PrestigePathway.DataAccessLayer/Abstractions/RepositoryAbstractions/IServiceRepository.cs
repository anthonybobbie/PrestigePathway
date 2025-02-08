using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}