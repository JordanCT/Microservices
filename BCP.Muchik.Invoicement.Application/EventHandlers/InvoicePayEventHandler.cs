using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Application.Events;
using BCP.Muchik.Invoicement.Application.Interfaces;

namespace BCP.Muchik.Invoicement.Application.EventHandlers
{
    public class InvoicePayEventHandler : IEventHandler<InvoicePayEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IInvoicementService _invoicementService;

        public InvoicePayEventHandler(IEventBus eventBus, IInvoicementService invoicementService)
        {
            _eventBus = eventBus;
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
