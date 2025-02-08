using PrestigePathway.DataAccessLayer.ModelsFolder;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions
{
    public interface ITestimonialRepository
    {
        Task<IEnumerable<Testimonial>> GetAllAsync();
        Task<Testimonial> GetByIdAsync(int id);
        Task AddAsync(Testimonial testimonial);
        Task UpdateAsync(Testimonial testimonial);
        Task DeleteAsync(int id);
    }
}