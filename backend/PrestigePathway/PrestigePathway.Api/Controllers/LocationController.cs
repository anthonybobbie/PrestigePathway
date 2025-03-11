using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Location;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class LocationController : BaseController<Location, ILocationService,LocationResponse,LocationPostRequest,LocationPutRequest>
    {
 
        public LocationController(IService<Location, LocationResponse>   locationService, ILogger<LocationController> logger)
            : base(locationService, logger) {}



        protected override int GetEntityId(Location entity) => entity.ID;
    }
}