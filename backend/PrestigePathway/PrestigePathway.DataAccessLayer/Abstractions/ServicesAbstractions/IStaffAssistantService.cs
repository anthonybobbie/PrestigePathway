using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions
{
    public interface IStaffAssistantService
    {
        Task<IEnumerable<StaffAssistant>> GetAllStaffAssistantsAsync();
        Task<StaffAssistant> GetStaffAssistantByIdAsync(int id);
        Task AddStaffAssistantAsync(StaffAssistant staffAssistant);
        Task UpdateStaffAssistantAsync(StaffAssistant staffAssistant);
        Task DeleteStaffAssistantAsync(int id);
    }
}