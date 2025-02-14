using PrestigePathway.Data.Models.Service;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IServiceService : IService<Service, ServiceResponse>
    {
        //Task<IEnumerable<Service>> GetAllAsync();
        //Task<Service> GetByIdAsync(int id);
        //Task AddAsync(Service service);
        //Task UpdateAsync(Service service);
        //Task DeleteAsync(int id);
    }
}