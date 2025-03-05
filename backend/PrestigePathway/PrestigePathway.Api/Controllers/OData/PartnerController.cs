using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class PartnerController : ODataBaseController<Payment>
    {
        public PartnerController(SocialServicesDbContext context) : base(context) { }
    }
}