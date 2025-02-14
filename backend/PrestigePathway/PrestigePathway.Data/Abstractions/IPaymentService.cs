using PrestigePathway.Data.Models.Payment;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions
{
    public interface IPaymentService : IService<Payment,PaymentResponse>
    {
        //Task<IEnumerable<Payment>> GetAllAsync();
        //Task<Payment> GetByIdAsync(int id);
        //Task AddAsync(Payment payment);
        //Task UpdateAsync(Payment payment);
        //Task DeleteAsync(int id);
    }
}