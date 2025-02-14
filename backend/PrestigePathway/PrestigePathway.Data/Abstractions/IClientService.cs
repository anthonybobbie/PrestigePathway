using PrestigePathway.Data.Models.Client;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IClientService : IService<Client,ClientResponse>
    {
        // Client-specific method
        Task<IEnumerable<Client>> SearchClientsByNameAsync(string name);
    }
}