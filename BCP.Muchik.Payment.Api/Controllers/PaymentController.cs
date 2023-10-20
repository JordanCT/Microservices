using BCP.Muchik.Payment.Application.Dtos;
using BCP.Muchik.Payment.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Muchik.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("registerPayment")]
        public async Task<IActionResult> RegisterPayment([FromBody] PayDto payDto)
        {
            var response = await _paymentService.RegisterPayment(payDto);
            return Ok(response);
        }
    }
}
