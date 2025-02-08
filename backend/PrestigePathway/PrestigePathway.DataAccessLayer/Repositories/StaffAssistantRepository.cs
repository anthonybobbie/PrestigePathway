using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class StaffAssistantRepository : IStaffAssistantRepository
    {
        private readonly SocialServicesDbContext _context;

        public StaffAssistantRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaffAssistant>> GetAllStaffAssistantsAsync()
        {
            return await _context.StaffAssistant
                .Include(sa => sa.Staff) // Include related Staff data
                .Include(sa => sa.Booking) // Include related Booking data
                .ToListAsync();
        }

        public async Task<StaffAssistant> GetStaffAssistantByIdAsync(int id)
        {
            return await _context.StaffAssistant
                .Include(sa => sa.Staff) // Include related Staff data
                .Include(sa => sa.Booking) // Include related Booking data
                .FirstOrDefaultAsync(sa => sa.ID == id);
        }

        public async Task AddStaffAssistantAsync(StaffAssistant staffAssistant)
        {
            _context.StaffAssistant.Add(staffAssistant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStaffAssistantAsync(StaffAssistant staffAssistant)
        {
            _context.Entry(staffAssistant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaffAssistantAsync(int id)
        {
            var staffAssistant = await _context.StaffAssistant.FindAsync(id);
            if (staffAssistant != null)
            {
                _context.StaffAssistant.Remove(staffAssistant);
                await _context.SaveChangesAsync();
            }
        }
    }
}