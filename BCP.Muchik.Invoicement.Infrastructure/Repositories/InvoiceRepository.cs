using BCP.Muchik.Invoicement.Domain.Entities;
using BCP.Muchik.Invoicement.Domain.Interfaces;
using BCP.Muchik.Invoicement.Infrastructure.Context;

namespace BCP.Muchik.Invoicement.Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoicementContext context) : base(context)
        {
        }
    }
}
