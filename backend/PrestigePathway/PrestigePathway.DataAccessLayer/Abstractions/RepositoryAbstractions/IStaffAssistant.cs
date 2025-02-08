using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IStaffAssistantRepository
    {
        Task<IEnumerable<StaffAssistant>> GetAllStaffAssistantsAsync();
        Task<StaffAssistant> GetStaffAssistantByIdAsync(int id);
        Task AddStaffAssistantAsync(StaffAssistant staffAssistant);
        Task UpdateStaffAssistantAsync(StaffAssistant staffAssistant);
        Task DeleteStaffAssistantAsync(int id);
    }
}