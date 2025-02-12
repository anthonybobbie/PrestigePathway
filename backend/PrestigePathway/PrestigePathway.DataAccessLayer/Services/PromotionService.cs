using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await _promotionRepository.GetAllPromotionsAsync();
        }

        public async Task<Promotion> GetByIdAsync(int id)
        {
            return await _promotionRepository.GetPromotionByIdAsync(id);
        }

        public async Task AddAsync(Promotion promotion)
        {
            await _promotionRepository.AddPromotionAsync(promotion);
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            await _promotionRepository.UpdatePromotionAsync(promotion);
        }

        public async Task DeleteAsync(int id)
        {
            await _promotionRepository.DeletePromotionAsync(id);
        }
    }
}