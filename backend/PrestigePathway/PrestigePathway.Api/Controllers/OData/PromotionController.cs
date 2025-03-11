using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class PromotionController : ODataBaseController<Promotion>
    {
        public PromotionController(SocialServicesDbContext context) : base(context) { }
    }
}