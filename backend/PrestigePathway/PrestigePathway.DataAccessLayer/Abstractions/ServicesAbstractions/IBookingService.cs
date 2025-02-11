using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions
{
    public interface IBookingService : IService<Booking>
    {
        //Booking specific-methods
        Task<IEnumerable<Booking>> GetBookingsByClientIdAsync(int clientId);
    }
}