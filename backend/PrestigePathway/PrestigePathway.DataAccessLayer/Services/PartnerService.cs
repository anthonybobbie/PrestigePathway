using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.BusinessLogicLayer.Abstractions;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public async Task AddAsync(Partner partner)
        {
            await _partnerRepository.AddAsync(partner);
        }

        public async Task DeleteAsync(int id)
        {
            await _partnerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            return await _partnerRepository.GetAllAsync();
        }

        public async Task<Partner> GetByIdAsync(int id)
        {
            return await _partnerRepository.GetByIdAsync(id);
        }

        //public async Task<IEnumerable<Partner>> GetPartnersByLocationAsync(string location)
        //{
        //    return await _partnerRepository.GetPartnersByLocationAsync(string location);
        //}

        public async Task UpdateAsync(Partner partner)
        {
            await _partnerRepository.UpdateAsync(partner);
        }
    }
}