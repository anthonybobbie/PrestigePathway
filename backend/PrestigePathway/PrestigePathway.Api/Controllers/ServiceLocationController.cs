using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceLocationController : ControllerBase
    {
        private readonly IServiceLocationService _serviceLocationService;

        public ServiceLocationController(IServiceLocationService serviceLocationService)
        {
            _serviceLocationService = serviceLocationService;
        }

        // GET: api/ServiceLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceLocation>>> GetServiceLocations()
        {
            var serviceLocations = await _serviceLocationService.GetAllServiceLocationsAsync();
            return Ok(serviceLocations);
        }

        // GET: api/ServiceLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceLocation>> GetServiceLocation(int id)
        {
            var serviceLocation = await _serviceLocationService.GetServiceLocationByIdAsync(id);

            if (serviceLocation == null)
            {
                return NotFound();
            }

            return serviceLocation;
        }

        // POST: api/ServiceLocation
        [HttpPost]
        public async Task<ActionResult<ServiceLocation>> PostServiceLocation(ServiceLocation serviceLocation)
        {
            await _serviceLocationService.AddServiceLocationAsync(serviceLocation);
            return CreatedAtAction(nameof(GetServiceLocation), new { id = serviceLocation.ID }, serviceLocation);
        }

        // PUT: api/ServiceLocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceLocation(int id, ServiceLocation serviceLocation)
        {
            if (id != serviceLocation.ID)
            {
                return BadRequest();
            }

            await _serviceLocationService.UpdateServiceLocationAsync(serviceLocation);
            return NoContent();
        }

        // DELETE: api/ServiceLocation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceLocation(int id)
        {
            await _serviceLocationService.DeleteServiceLocationAsync(id);
            return NoContent();
        }
    }
}