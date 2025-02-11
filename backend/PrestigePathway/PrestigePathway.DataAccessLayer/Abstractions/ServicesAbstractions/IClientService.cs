using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;

public interface IClientService : IService<Client>
{
    // Client-specific method
    Task<IEnumerable<Client>> SearchClientsByNameAsync(string name);
}