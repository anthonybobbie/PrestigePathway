using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class StaffAssistantService : IStaffAssistantService
    {
        private readonly IStaffAssistantRepository _staffAssistantRepository;

        public StaffAssistantService(IStaffAssistantRepository staffAssistantRepository)
        {
            _staffAssistantRepository = staffAssistantRepository;
        }

        public async Task<IEnumerable<StaffAssistant>> GetAllStaffAssistantsAsync()
        {
            return await _staffAssistantRepository.GetAllStaffAssistantsAsync();
        }

        public async Task<StaffAssistant> GetStaffAssistantByIdAsync(int id)
        {
            return await _staffAssistantRepository.GetStaffAssistantByIdAsync(id);
        }

        public async Task AddStaffAssistantAsync(StaffAssistant staffAssistant)
        {
            await _staffAssistantRepository.AddStaffAssistantAsync(staffAssistant);
        }

        public async Task UpdateStaffAssistantAsync(StaffAssistant staffAssistant)
        {
            await _staffAssistantRepository.UpdateStaffAssistantAsync(staffAssistant);
        }

        public async Task DeleteStaffAssistantAsync(int id)
        {
            await _staffAssistantRepository.DeleteStaffAssistantAsync(id);
        }
    }
}