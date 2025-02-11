using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<IEnumerable<Testimonial>> GetAllAsync()
        {
            return await _testimonialRepository.GetAllAsync();
        }

        public async Task<Testimonial> GetByIdAsync(int id)
        {
            return await _testimonialRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Testimonial testimonial)
        {
            await _testimonialRepository.AddAsync(testimonial);
        }

        public async Task UpdateAsync(Testimonial testimonial)
        {
            await _testimonialRepository.UpdateAsync(testimonial);
        }

        public async Task DeleteAsync(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
        }
    }
}