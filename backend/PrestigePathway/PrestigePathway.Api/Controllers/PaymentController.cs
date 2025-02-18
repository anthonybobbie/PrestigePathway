using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Partner;
using PrestigePathway.Data.Models.Payment;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class PaymentController : BaseController<Payment, IPaymentService, PaymentResponse,PaymentPostRequest, PaymentPutRequest>
    {
 
        public PaymentController(IService<Payment, PaymentResponse> paymentService, ILogger<PaymentController> logger) 
            : base(paymentService, logger) 
        {
        }

        protected override int GetEntityId(Payment entity) => entity.ID;
    }
}