using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ServiceController : ODataBaseController<Service>
    {
        public ServiceController(SocialServicesDbContext context) : base(context) { }
    }
}