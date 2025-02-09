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
    public class StaffAssistantController : ControllerBase
    {
        private readonly IStaffAssistantService _staffAssistantService;

        public StaffAssistantController(IStaffAssistantService staffAssistantService)
        {
            _staffAssistantService = staffAssistantService;
        }

        // GET: api/StaffAssistant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffAssistant>>> GetStaffAssistant()
        {
            var staffAssistants = await _staffAssistantService.GetAllStaffAssistantsAsync();
            return Ok(staffAssistants);
        }

        // GET: api/StaffAssistant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffAssistant>> GetStaffAssistant(int id)
        {
            var staffAssistant = await _staffAssistantService.GetStaffAssistantByIdAsync(id);
            if (staffAssistant == null)
            {
                return BadRequest();
            }

            return staffAssistant;
        }

        // POST: api/StaffAssistant
        [HttpPost]
        public async Task<ActionResult<StaffAssistant>> PostStaffAssistant(StaffAssistant staffAssistant)
        {
            await _staffAssistantService.AddStaffAssistantAsync(staffAssistant);
            return CreatedAtAction(nameof(GetStaffAssistant), new { id = staffAssistant.ID }, staffAssistant);
        }

        // PUT: api/StaffAssistant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAssistant(int id, StaffAssistant staffAssistant)
        {
            if (id != staffAssistant.ID)
            {
                return BadRequest();
            }

            await _staffAssistantService.UpdateStaffAssistantAsync(staffAssistant);
            return NoContent();
        }

        // DELETE: api/StaffAssistant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAssistant(int id)
        {
            await _staffAssistantService.DeleteStaffAssistantAsync(id);
            return NoContent();
        }
    }
}