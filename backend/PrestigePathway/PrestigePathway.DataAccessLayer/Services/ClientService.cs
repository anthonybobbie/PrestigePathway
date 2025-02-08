using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepository.DeleteClientAsync(id);
        }
    }
}