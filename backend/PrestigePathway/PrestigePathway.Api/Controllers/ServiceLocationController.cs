using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Service;
using PrestigePathway.Data.Models.ServiceLocation;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class ServiceLocationController : BaseController<ServiceLocation, IServiceLocationService, ServiceLocationResponse,ServiceLocationPostRequest,ServiceLocationPutRequest>
    {
 
        public ServiceLocationController(IService<ServiceLocation, ServiceLocationResponse> serviceLocationService, ILogger<ServiceLocationController> logger) : base(serviceLocationService, logger) 
        {
        }

        protected override int GetEntityId(ServiceLocation entity) => entity.ID;
    }
}