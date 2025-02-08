using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.ModelsFolder;
using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            var staff = await _staffService.GetAllStaffAsync();
            return Ok(staff);
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            await _staffService.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaff), new { id = staff.ID }, staff);
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.ID)
            {
                return BadRequest();
            }

            await _staffService.UpdateStaffAsync(staff);
            return NoContent();
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            await _staffService.DeleteStaffAsync(id);
            return NoContent();
        }
    }
}