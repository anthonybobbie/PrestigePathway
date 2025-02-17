using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.ServicePartner;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers;

public class ServicePartnerController : BaseController<ServicePartner, IServicePartnerService, ServicePartnerResponse,ServicePartnerPostRequest,ServicePartnerPutRequest>
{
    public ServicePartnerController(IService<ServicePartner, ServicePartnerResponse> servicePartnerService, 
        ILogger<ServicePartnerController> logger) : base(servicePartnerService, logger)
    {
        
    }

    protected override int GetEntityId(ServicePartner entity) => entity.ID;
}