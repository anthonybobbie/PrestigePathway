using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ServicePartnerController : ODataBaseController<ServicePartner>
    {
        public ServicePartnerController(SocialServicesDbContext context) : base(context) { }
    }
}