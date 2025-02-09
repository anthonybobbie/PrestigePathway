using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        // Example of a shared method
        protected IActionResult HandleError(Exception ex, string message = "An error occurred.")
        {
            _logger.LogError(ex, message);
            return StatusCode(500, new { Message = message, Details = ex.Message });
        }
    }
}
