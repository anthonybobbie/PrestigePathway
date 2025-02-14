using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Booking;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class BookingController : BaseController<Booking, IBookingService,BookingResponse>
    {
        public BookingController(IService<Booking, BookingResponse>   bookingService, ILogger<BookingController> logger)
            : base(bookingService, logger)
        {
        }
        protected override int GetEntityId(Booking entity) => entity.ID;

         
    }
}
