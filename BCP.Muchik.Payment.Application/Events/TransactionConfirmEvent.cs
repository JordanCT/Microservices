using BCP.Muchik.Infrastructure.EventBus.Events;

namespace BCP.Muchik.Payment.Application.Events
{
    public class TransactionConfirmEvent : Event
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public TransactionConfirmEvent(int invoiceId, decimal amount, DateTime createdAt)
        {
            InvoiceId = invoiceId;
            Amount = amount;
            CreatedAt = createdAt;
        }
    }
}
