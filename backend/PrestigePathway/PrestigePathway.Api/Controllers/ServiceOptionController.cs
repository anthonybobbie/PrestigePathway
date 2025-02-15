using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.ServiceOption;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers;

public class ServiceOptionController : BaseController<ServiceOption, IServiceOptionService, ServiceOptionResponse>
{
    public ServiceOptionController(IService<ServiceOption, ServiceOptionResponse> serviceOptionService, 
        ILogger<ServiceOptionController> logger) : base(serviceOptionService, logger)
    {
        
    }
    
    protected override int GetEntityId(ServiceOption entity) => entity.ID;
}