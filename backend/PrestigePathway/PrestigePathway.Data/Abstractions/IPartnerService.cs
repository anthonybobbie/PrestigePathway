using PrestigePathway.Data.Models.Partner;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IPartnerService : IService<Partner, PartnerResponse>
    {
       
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetByIdAsync(int id);
        Task<Partner> AddAsync(Partner entity);
        Task<Partner> UpdateAsync(Partner entity);
        Task<bool> DeleteAsync(int id);
     }
}