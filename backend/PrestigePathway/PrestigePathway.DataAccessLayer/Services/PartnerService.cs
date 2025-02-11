using PrestigePathway.BusinessLogicLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

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

        public async Task UpdateAsync(Partner entity)
        {
            await _partnerRepository.UpdateAsync(entity);
        }
            
        //public async Task<IEnumerable<Partner>> GetPartnersByLocationAsync(string location)
        //{
        //    return await _partnerRepository.GetPartnersByLocationAsync(string location);
        //}

    }
}