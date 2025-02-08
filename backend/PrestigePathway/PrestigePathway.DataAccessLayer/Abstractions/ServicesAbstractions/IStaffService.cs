using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task AddStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(int id);
    }
}