using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}