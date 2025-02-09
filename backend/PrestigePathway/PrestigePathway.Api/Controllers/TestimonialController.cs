using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TestimonialController : ControllerBase
    {
        private readonly SocialServicesDbContext _context;

        public TestimonialController(SocialServicesDbContext context)
        {
            _context = context;
        }

        // GET: api/Testimonial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            return await _context.Testimonials
                .Include(t => t.Client) // Include related Client data
                .ToListAsync();
        }

        // GET: api/Testimonial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
        {
            var testimonial = await _context.Testimonials
                .Include(t => t.Client) // Include related Client data
                .FirstOrDefaultAsync(t => t.ID == id);

            if (testimonial == null)
            {
                return NotFound();
            }

            return testimonial;
        }

        // POST: api/Testimonial
        [HttpPost]
        public async Task<ActionResult<Testimonial>> PostTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();

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

            _context.Entry(testimonial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Testimonials.Any(e => e.ID == id))
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

        // DELETE: api/Testimonial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}