using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocation), new { id = location.ID }, location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.ID)
            {
                return BadRequest();
            }

            await _locationService.UpdateLocationAsync(location);
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return NoContent();
        }
    }
}