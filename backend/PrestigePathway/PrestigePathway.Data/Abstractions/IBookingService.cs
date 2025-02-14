using PrestigePathway.Data.Models.Booking;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IBookingService : IService<Booking,BookingResponse>
    {
        //Booking specific-methods
        Task<IEnumerable<Booking>> GetBookingsByClientIdAsync(int clientId);
    }
}