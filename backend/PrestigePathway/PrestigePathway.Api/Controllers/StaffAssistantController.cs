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
    public class StaffAssistantController : ControllerBase
    {
        private readonly SocialServicesDbContext _context;

        public StaffAssistantController(SocialServicesDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffAssistant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffAssistant>>> GetStaffAssistant()
        {
            return await _context.StaffAssistant
                .Include(sa => sa.Staff)
                .Include(sa => sa.Booking)
                .ToListAsync();
        }

        // GET: api/StaffAssistant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffAssistant>> GetStaffAssistant(int id)
        {
            var staffAssistant = await _context.StaffAssistant
                .Include(sa => sa.Staff)
                .Include(sa => sa.Booking)
                .FirstOrDefaultAsync(sa => sa.StaffAssistantID == id);

            if (staffAssistant == null)
            {
                return NotFound();
            }

            return staffAssistant;
        }

        // POST: api/StaffAssistant
        [HttpPost]
        public async Task<ActionResult<StaffAssistant>> PostStaffAssistant(StaffAssistant staffAssistant)
        {
            _context.StaffAssistant.Add(staffAssistant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffAssistant), new { id = staffAssistant.StaffAssistantID }, staffAssistant);
        }

        // PUT: api/StaffAssistant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAssistant(int id, StaffAssistant staffAssistant)
        {
            if (id != staffAssistant.StaffAssistantID)
            {
                return BadRequest();
            }

            _context.Entry(staffAssistant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.StaffAssistant.Any(e => e.StaffAssistantID == id))
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

        // DELETE: api/StaffAssistant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAssistant(int id)
        {
            var staffAssistant = await _context.StaffAssistant.FindAsync(id);
            if (staffAssistant == null)
            {
                return NotFound();
            }

            _context.StaffAssistant.Remove(staffAssistant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}