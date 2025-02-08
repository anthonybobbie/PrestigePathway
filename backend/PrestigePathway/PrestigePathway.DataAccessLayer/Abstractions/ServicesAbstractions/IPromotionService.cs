using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        Task<Promotion> GetPromotionByIdAsync(int id);
        Task AddPromotionAsync(Promotion promotion);
        Task UpdatePromotionAsync(Promotion promotion);
        Task DeletePromotionAsync(int id);
    }
}