using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromotionController : BaseController<Promotion, IPromotionService>
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService, ILogger<PromotionController> logger) 
            : base(promotionService, logger)
        {
        } 
    }
}