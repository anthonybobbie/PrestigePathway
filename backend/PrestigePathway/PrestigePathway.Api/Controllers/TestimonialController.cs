using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Staff;
using PrestigePathway.Data.Models.Testimonial;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class TestimonialController : BaseController<Testimonial, ITestimonialService, TestimonialResponse>
    {
 
        public TestimonialController(IService<Testimonial, TestimonialResponse>   testimonialService, ILogger<TestimonialController> logger)
            : base(testimonialService, logger) 
        {
        }

        protected override int GetEntityId(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}