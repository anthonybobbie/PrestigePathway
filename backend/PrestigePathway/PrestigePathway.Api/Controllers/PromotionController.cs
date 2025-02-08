using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.ModelsFolder;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        // GET: api/Promotion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
        {
            var promotions = await _promotionService.GetAllPromotionsAsync();
            return Ok(promotions);
        }

        // GET: api/Promotion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetPromotion(int id)
        {
            var promotion = await _promotionService.GetPromotionByIdAsync(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return promotion;
        }

        // POST: api/Promotion
        [HttpPost]
        public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
        {
            await _promotionService.AddPromotionAsync(promotion);
            return CreatedAtAction(nameof(GetPromotion), new { id = promotion.ID }, promotion);
        }

        // PUT: api/Promotion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, Promotion promotion)
        {
            if (id != promotion.ID)
            {
                return BadRequest();
            }

            await _promotionService.UpdatePromotionAsync(promotion);
            return NoContent();
        }

        // DELETE: api/Promotion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            await _promotionService.DeletePromotionAsync(id);
            return NoContent();
        }
    }
}