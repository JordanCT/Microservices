using BCP.Muchik.Invoicement.Application.Dtos;

namespace BCP.Muchik.Invoicement.Application.Interfaces
{
    public interface IInvoicementService
    {
        ICollection<InvoiceDto> GetAllInvoives();
        InvoiceDto CreateInvoice(CreateInvoiceDto createInvoiceDto);
        bool PayInvoice(PayInvoiceDto payInvoiceDto);
    }
}
