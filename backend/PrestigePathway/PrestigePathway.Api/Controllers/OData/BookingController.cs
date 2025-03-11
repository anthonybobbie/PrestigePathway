using Microsoft.AspNetCore.OData.Routing.Controllers;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer;

namespace PrestigePathway.Api.Controllers.OData
{
    public class BookingController : ODataBaseController<Booking>
    {
        public BookingController(SocialServicesDbContext context) : base(context) { }
    }
}
