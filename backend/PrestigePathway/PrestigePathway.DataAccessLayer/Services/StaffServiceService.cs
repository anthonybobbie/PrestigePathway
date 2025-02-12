using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Services
{
    public class StaffServiceService : IStaffService
    {
        private readonly IStaffRepository _repository;

        public StaffServiceService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Staff entity)
        {
            await _repository.AddStaffAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteStaffAsync(id);
        }

        public Task<IEnumerable<Staff>> GetAllAsync()
        {
            return _repository.GetAllStaffAsync();
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _repository.GetStaffByIdAsync(id);
        }

        public async Task UpdateAsync(Staff entity)
        {
            await _repository.UpdateStaffAsync(entity);
        }
    }
}
