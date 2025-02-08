using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllStaffAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _staffRepository.GetStaffByIdAsync(id);
        }

        public async Task AddStaffAsync(Staff staff)
        {
            await _staffRepository.AddStaffAsync(staff);
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            await _staffRepository.UpdateStaffAsync(staff);
        }

        public async Task DeleteStaffAsync(int id)
        {
            await _staffRepository.DeleteStaffAsync(id);
        }
    }
}