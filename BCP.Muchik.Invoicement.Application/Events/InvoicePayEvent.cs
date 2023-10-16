using BCP.Muchik.Infrastructure.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Muchik.Invoicement.Application.Events
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
