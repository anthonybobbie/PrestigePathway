using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ServiceOptionController : ODataBaseController<ServiceOption>
    {
        public ServiceOptionController(SocialServicesDbContext context) : base(context) { }
    }
}