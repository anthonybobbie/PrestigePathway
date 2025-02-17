using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.ServiceType;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers;

public class ServiceTypeController : BaseController<ServiceType, IServiceTypeService, ServiceTypeResponse,ServiceTypePostRequest,ServiceTypePutRequest>
{
    public ServiceTypeController(IService<ServiceType, ServiceTypeResponse> serviceTypeService, 
        ILogger<ServiceTypeController> logger) : base(serviceTypeService, logger)
    {
        
    }

    protected override int GetEntityId(ServiceType entity) => entity.ID;
}