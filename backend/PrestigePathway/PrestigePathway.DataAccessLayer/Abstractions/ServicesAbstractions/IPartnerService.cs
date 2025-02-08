using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllPartnersAsync();
        Task<Partner> GetPartnerByIdAsync(int id);
        Task AddPartnerAsync(Partner partner);
        Task UpdatePartnerAsync(Partner partner);
        Task DeletePartnerAsync(int id);
    }
}