using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SocialServicesDbContext _context;

        public PaymentRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments
                .Include(p => p.Booking) // Include related Booking data
                .ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Booking) // Include related Booking data
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}