using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Abstractions
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetByIdAsync(int id);
        Task AddAsync(Partner partner);
        Task UpdateAsync(Partner partner);
        Task DeleteAsync(int id);

        //Task<IEnumerable<Partner>> GetPartnersByLocationAsync(string location);
    }
}