using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ServiceLocationController : ODataBaseController<ServiceLocation>
    {
        public ServiceLocationController(SocialServicesDbContext context) : base(context) { }
    }
}