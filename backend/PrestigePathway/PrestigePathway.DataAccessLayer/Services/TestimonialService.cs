using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync()
        {
            return await _testimonialRepository.GetAllAsync();
        }

        public async Task<Testimonial> GetTestimonialByIdAsync(int id)
        {
            return await _testimonialRepository.GetByIdAsync(id);
        }

        public async Task AddTestimonialAsync(Testimonial testimonial)
        {
            await _testimonialRepository.AddAsync(testimonial);
        }

        public async Task UpdateTestimonialAsync(Testimonial testimonial)
        {
            await _testimonialRepository.UpdateAsync(testimonial);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
        }
    }
}