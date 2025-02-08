using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}