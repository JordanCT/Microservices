using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Muchik.Invoicement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicementController : ControllerBase
    {
        private readonly IInvoicementService _invoicementService;
        public InvoicementController(IInvoicementService invoicementService)
        {
            _invoicementService = invoicementService;
        }

        [HttpGet("getAllInvoices")]
        public IActionResult GetAllInvoices() 
        { 
            return Ok(_invoicementService.GetAllInvoives());
        }

        [HttpPost("createInvoice")]
        public IActionResult CreateInvoice([FromBody] CreateInvoiceDto createInvoiceDto) 
        {
            return Ok(_invoicementService.CreateInvoice(createInvoiceDto));
        }
    }
}
