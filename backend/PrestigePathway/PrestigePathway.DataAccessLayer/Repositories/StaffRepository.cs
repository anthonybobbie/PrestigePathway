using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.ModelsFolder;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly SocialServicesDbContext _context;

        public StaffRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _context.Staff.FindAsync(id);
        }

        public async Task AddStaffAsync(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}