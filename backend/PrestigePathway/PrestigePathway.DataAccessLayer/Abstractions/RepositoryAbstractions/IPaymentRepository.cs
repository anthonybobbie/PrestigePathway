using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);
    }
}