using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentController : BaseController<Payment, IPaymentService>
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger) 
            : base(paymentService, logger) 
        {
        }
    }
}