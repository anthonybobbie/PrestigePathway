using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class LocationController : ODataBaseController<Location>
    {
        public LocationController(SocialServicesDbContext context) : base(context) { }
    }
}