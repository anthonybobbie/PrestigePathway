using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task AddStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(int id);
    }
}