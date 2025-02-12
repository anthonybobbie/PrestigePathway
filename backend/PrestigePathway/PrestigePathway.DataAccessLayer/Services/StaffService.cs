using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _staffRepository.GetAllStaffAsync();
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _staffRepository.GetStaffByIdAsync(id);
        }

        public async Task AddAsync(Staff staff)
        {
            await _staffRepository.AddStaffAsync(staff);
        }

        public async Task UpdateAsync(Staff staff)
        {
            await _staffRepository.UpdateStaffAsync(staff);
        }

        public async Task DeleteAsync(int id)
        {
            await _staffRepository.DeleteStaffAsync(id);
        }
    }
}