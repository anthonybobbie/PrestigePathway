using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersAsync()
        {
            return await _partnerRepository.GetAllPartnersAsync();
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            return await _partnerRepository.GetPartnerByIdAsync(id);
        }

        public async Task AddPartnerAsync(Partner partner)
        {
            await _partnerRepository.AddPartnerAsync(partner);
        }

        public async Task UpdatePartnerAsync(Partner partner)
        {
            await _partnerRepository.UpdatePartnerAsync(partner);
        }

        public async Task DeletePartnerAsync(int id)
        {
            await _partnerRepository.DeletePartnerAsync(id);
        }
    }
}