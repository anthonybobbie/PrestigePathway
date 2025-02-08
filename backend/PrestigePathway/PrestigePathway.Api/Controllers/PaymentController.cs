using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _paymentService.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = payment.ID }, payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.ID)
            {
                return BadRequest();
            }

            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}