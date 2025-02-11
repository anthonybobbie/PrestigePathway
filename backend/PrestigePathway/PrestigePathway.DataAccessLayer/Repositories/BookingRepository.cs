using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SocialServicesDbContext _context;

    public BookingRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Service)
                .ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByClientIdAsync(int clientId)
        {
            return await _context.Bookings
                .Where(b => b.ClientID == clientId)
                .ToListAsync();
        }
    }
}