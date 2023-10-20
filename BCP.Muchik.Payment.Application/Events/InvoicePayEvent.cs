using BCP.Muchik.Infrastructure.EventBus.Events;

namespace BCP.Muchik.Payment.Application.Events
{
    public class InvoicePayEvent : Event
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }

        public InvoicePayEvent(int invoiceId, decimal amount)
        {
            InvoiceId = invoiceId;
            Amount = amount;
        }
    }
}
