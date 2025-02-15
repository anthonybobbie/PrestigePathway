using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.ServiceDetail;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers;

public class ServiceDetailController : BaseController<ServiceDetail, IServiceDetailService, ServiceDetailResponse>
{
    public ServiceDetailController(IService<ServiceDetail, ServiceDetailResponse> serviceDetailService,
        ILogger<ServiceDetailController> logger)
        : base(serviceDetailService, logger)
    {
    }

    protected override int GetEntityId(ServiceDetail entity) => entity.ID;
}