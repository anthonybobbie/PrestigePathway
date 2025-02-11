using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task AddAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteClientAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            return _clientRepository.GetClientByIdAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }

        public async Task<IEnumerable<Client>> SearchClientsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}