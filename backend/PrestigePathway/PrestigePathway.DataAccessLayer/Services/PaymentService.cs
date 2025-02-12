using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.BusinessLogicLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _paymentRepository.AddPaymentAsync(payment);
        }

        public async Task UpdateAsync(Payment payment)
        {
            await _paymentRepository.UpdatePaymentAsync(payment);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
        }
    }
}