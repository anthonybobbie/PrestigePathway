using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly SocialServicesDbContext _context;

        public TestimonialRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Testimonial>> GetAllAsync()
        {
            return await _context.Testimonials
                .Include(t => t.Client) // Include related Client data
                .ToListAsync();
        }

        public async Task<Testimonial> GetByIdAsync(int id)
        {
            return await _context.Testimonials
                .Include(t => t.Client) // Include related Client data
                .FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddAsync(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Testimonial testimonial)
        {
            _context.Entry(testimonial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                await _context.SaveChangesAsync();
            }
        }
    }
}