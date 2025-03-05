using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Api.Infrastructure;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Booking;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class BookingController : BaseController<Booking, IBookingService,BookingResponse,BookingPostRequest,BookingPutRequest>
    {
        public BookingController(IService<Booking, BookingResponse>   bookingService, ILogger<BookingController> logger)
            : base(bookingService, logger)
        {
        }
        protected override int GetEntityId(Booking entity) => entity.ID;

        // GET: api/[controller]
        [HttpGet("Service/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [PermissionAuthorize(permission:"Booking_Service_GET")]
        public virtual async Task<IActionResult> GetBookingByServiceID([FromRoute] int id)
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return DataResponse("Fetched successfully", entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching entities.");
                return HandleError(ex, "An error occurred while fetching entities.");
            }
        }
    }
}
