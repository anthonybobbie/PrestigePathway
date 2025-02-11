using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public async Task AddAsync(Booking booking)
        {
            await _repository.AddAsync(booking);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByClientIdAsync(int clientId)
        {
            return await _repository.GetBookingsByClientIdAsync(clientId);
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            await _repository.UpdateAsync(booking);
        }
    }
}