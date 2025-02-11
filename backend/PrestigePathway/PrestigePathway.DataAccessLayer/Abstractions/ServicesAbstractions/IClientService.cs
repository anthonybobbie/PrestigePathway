using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions
{
    public interface IClientService : IService<Client>
    {
        // Client-specific method
        Task<IEnumerable<Client>> SearchClientsByNameAsync(string name);
    }
}