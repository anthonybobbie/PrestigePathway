using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.BusinessLogicLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PartnerController : BaseController<Partner, IPartnerService>
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService, ILogger<PartnerController> logger) 
            : base(partnerService, logger) 
        {
        }
    }
}