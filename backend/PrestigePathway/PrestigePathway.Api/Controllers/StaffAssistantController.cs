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
    public class StaffAssistantController : BaseController<StaffAssistant, IStaffAssistantService>
    {
        private readonly IStaffAssistantService _staffAssistantService;

        public StaffAssistantController(IStaffAssistantService staffAssistantService, ILogger<StaffAssistantController> logger) : base(staffAssistantService, logger)
        {
        }
    }
}