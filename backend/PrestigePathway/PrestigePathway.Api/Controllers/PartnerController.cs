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
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: api/Partner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
        {
            var partners = await _partnerService.GetAllPartnersAsync();
            return Ok(partners);
        }

        // GET: api/Partner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartner(int id)
        {
            var partner = await _partnerService.GetPartnerByIdAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            return partner;
        }

        // POST: api/Partner
        [HttpPost]
        public async Task<ActionResult<Partner>> PostPartner(Partner partner)
        {
            await _partnerService.AddPartnerAsync(partner);
            return CreatedAtAction(nameof(GetPartner), new { id = partner.ID }, partner);
        }

        // PUT: api/Partner/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartner(int id, Partner partner)
        {
            if (id != partner.ID)
            {
                return BadRequest();
            }

            await _partnerService.UpdatePartnerAsync(partner);
            return NoContent();
        }

        // DELETE: api/Partner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            await _partnerService.DeletePartnerAsync(id);
            return NoContent();
        }
    }
}