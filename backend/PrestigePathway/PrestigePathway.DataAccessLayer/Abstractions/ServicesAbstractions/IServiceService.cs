using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}