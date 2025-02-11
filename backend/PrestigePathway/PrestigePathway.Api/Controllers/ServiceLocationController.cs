using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceLocationController : BaseController<ServiceLocation, IServiceLocationService>
    {
        private readonly IServiceLocationService _serviceLocationService;

        public ServiceLocationController(IServiceLocationService serviceLocationService, ILogger<ServiceLocationController> logger) : base(serviceLocationService, logger) 
        {
        }
    }
}