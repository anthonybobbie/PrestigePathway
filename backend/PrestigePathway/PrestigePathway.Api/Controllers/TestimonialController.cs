using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.ModelsFolder;
using PrestigePathway.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // GET: api/Testimonial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            var testimonials = await _testimonialService.GetAllTestimonialsAsync();
            return Ok(testimonials);
        }

        // GET: api/Testimonial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);

            if (testimonial == null)
            {
                return NotFound();
            }

            return Ok(testimonial);
        }

        // POST: api/Testimonial
        [HttpPost]
        public async Task<ActionResult<Testimonial>> PostTestimonial(Testimonial testimonial)
        {
            await _testimonialService.AddTestimonialAsync(testimonial);
            return CreatedAtAction(nameof(GetTestimonial), new { id = testimonial.ID }, testimonial);
        }

        // PUT: api/Testimonial/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonial(int id, Testimonial testimonial)
        {
            if (id != testimonial.ID)
            {
                return BadRequest();
            }

            await _testimonialService.UpdateTestimonialAsync(testimonial);
            return NoContent();
        }

        // DELETE: api/Testimonial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return NoContent();
        }
    }
}