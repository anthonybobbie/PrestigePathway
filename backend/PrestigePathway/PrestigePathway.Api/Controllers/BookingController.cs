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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.ID }, booking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.ID)
            {
                return BadRequest();
            }

            await _bookingService.UpdateBookingAsync(booking);
            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}