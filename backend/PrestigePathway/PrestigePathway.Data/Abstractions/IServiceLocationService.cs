using PrestigePathway.Data.Models.ServiceLocation;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IServiceLocationService : IService<ServiceLocation, ServiceLocationResponse>
    {
        //Task<IEnumerable<ServiceLocation>> GetAllServiceLocationsAsync();
        //Task<ServiceLocation> GetServiceLocationByIdAsync(int id);
        //Task AddServiceLocationAsync(ServiceLocation serviceLocation);
        //Task UpdateServiceLocationAsync(ServiceLocation serviceLocation);
        //Task DeleteServiceLocationAsync(int id);
    }
}