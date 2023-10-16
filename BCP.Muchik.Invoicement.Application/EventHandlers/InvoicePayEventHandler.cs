using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Application.Events;
using BCP.Muchik.Invoicement.Application.Interfaces;

namespace BCP.Muchik.Invoicement.Application.EventHandlers
{
    public class InvoicePayEventHandler : IEventHandler<InvoicePayEvent>
    {
        private readonly IInvoicementService _invoicementService;

        public InvoicePayEventHandler(IInvoicementService invoicementService)
        {
            _invoicementService = invoicementService;
        }
    
        public Task Handle(InvoicePayEvent @event)
        {
            var payInvoiceDto = new PayInvoiceDto
            {
                Id = @event.InvoiceId,
                Amount = @event.Amount
            };

            _invoicementService.PayInvoice(payInvoiceDto);

            return Task.CompletedTask;
        }
    }
}
