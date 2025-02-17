using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Service;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class ServiceController : BaseController<Service, IServiceService, ServiceResponse>
    {
        public ServiceController(IService<Service, ServiceResponse> serviceService, ILogger<ServiceController> logger) : base(serviceService, logger) 
        {
        }

        protected override int GetEntityId(Service entity) => entity.ID;
    }
}