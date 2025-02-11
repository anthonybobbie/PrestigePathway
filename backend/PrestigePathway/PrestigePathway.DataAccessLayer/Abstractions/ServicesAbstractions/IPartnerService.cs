using PrestigePathway.BusinessLogicLayer.Services;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Abstractions
{
    public interface IPartnerService : IService<Partner>
    {
        //Partner specific-methods
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetByIdAsync(int id);
        Task AddAsync(Partner entity);
        Task UpdateAsync(Partner entity);
        Task DeleteAsync(int id);
        //Task<IEnumerable<Partner>> GetPartnersByLocationAsync(string location);
    }
}