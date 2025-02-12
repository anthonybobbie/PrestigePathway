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

        public async Task<IEnumerable<StaffAssistant>> GetAllAsync()
        {
            return await _staffAssistantRepository.GetAllStaffAssistantsAsync();
        }

        public async Task<StaffAssistant> GetByIdAsync(int id)
        {
            return await _staffAssistantRepository.GetStaffAssistantByIdAsync(id);
        }

        public async Task AddAsync(StaffAssistant staffAssistant)
        {
            await _staffAssistantRepository.AddStaffAssistantAsync(staffAssistant);
        }

        public async Task UpdateAsync(StaffAssistant staffAssistant)
        {
            await _staffAssistantRepository.UpdateStaffAssistantAsync(staffAssistant);
        }

        public async Task DeleteAsync(int id)
        {
            await _staffAssistantRepository.DeleteStaffAssistantAsync(id);
        }
    }
}