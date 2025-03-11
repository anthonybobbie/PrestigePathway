using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ServiceTypeController : ODataBaseController<ServiceType>
    {
        public ServiceTypeController(SocialServicesDbContext context) : base(context) { }
    }
}