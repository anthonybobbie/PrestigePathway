using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.NewFolder;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceLocationController : ControllerBase
    {
        private readonly SocialServicesDbContext _context;

        public ServiceLocationController(SocialServicesDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceLocation>>> GetServiceLocations()
        {
            return await _context.ServiceLocations
                .Include(sl => sl.Service) // Include related Service data
                .Include(sl => sl.Location) // Include related Location data
                .ToListAsync();
        }

        // GET: api/ServiceLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceLocation>> GetServiceLocation(int id)
        {
            var serviceLocation = await _context.ServiceLocations
                .Include(sl => sl.Service) // Include related Service data
                .Include(sl => sl.Location) // Include related Location data
                .FirstOrDefaultAsync(sl => sl.ID == id);

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
            _context.ServiceLocations.Add(serviceLocation);
            await _context.SaveChangesAsync();

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

            _context.Entry(serviceLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ServiceLocations.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ServiceLocation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceLocation(int id)
        {
            var serviceLocation = await _context.ServiceLocations.FindAsync(id);
            if (serviceLocation == null)
            {
                return NotFound();
            }

            _context.ServiceLocations.Remove(serviceLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}