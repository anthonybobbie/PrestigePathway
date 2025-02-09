using PrestigePathway.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface ITestimonialService
    {
        Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync();
        Task<Testimonial> GetTestimonialByIdAsync(int id);
        Task AddTestimonialAsync(Testimonial testimonial);
        Task UpdateTestimonialAsync(Testimonial testimonial);
        Task DeleteTestimonialAsync(int id);
    }
}