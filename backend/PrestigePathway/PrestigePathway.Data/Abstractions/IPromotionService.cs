using PrestigePathway.Data.Models.Promotion;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IPromotionService : IService<Promotion, PromotionResponse>
    {
        //Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        //Task<Promotion> GetPromotionByIdAsync(int id);
        //Task AddPromotionAsync(Promotion promotion);
        //Task UpdatePromotionAsync(Promotion promotion);
        //Task DeletePromotionAsync(int id);
    }
}