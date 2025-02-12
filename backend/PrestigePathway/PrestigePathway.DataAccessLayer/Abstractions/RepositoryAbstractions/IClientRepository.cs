using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task AddClientAsync(Client promotion);
        Task UpdateClientAsync(Client promotion);
        Task DeleteClientAsync(int id);
        Task<IEnumerable<Client>> SearchClientsByNameAsync(string name);
    }
}