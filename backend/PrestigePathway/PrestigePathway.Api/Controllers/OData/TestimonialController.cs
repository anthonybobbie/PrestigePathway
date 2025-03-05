using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class TestimonialController : ODataBaseController<Testimonial>
    {
        public TestimonialController(SocialServicesDbContext context) : base(context) { }
    }
}