using BCP.Muchik.Movement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Muchik.Movement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet("getAllTransactionsFromInvoice/{invoiceId}")]
        public IActionResult GetAllTransactionsFromInvoice(int invoiceId)
        {
            return Ok(_movementService.GetAllTransactionsFromInvoice(invoiceId));
        }
    }
}
