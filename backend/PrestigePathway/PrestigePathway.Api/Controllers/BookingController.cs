using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingController : BaseController<Booking, IBookingService>
    {
        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
            : base(bookingService, logger)
        {
        }

        protected override int GetEntityId(Booking entity) => entity.ID;

        [HttpGet("SearchBookingByClientId")]
        public async Task<IEnumerable<Booking>> SearchByClientId(int clientId)
        {
            return await _service.GetBookingsByClientIdAsync(clientId);
        }
    }
}
