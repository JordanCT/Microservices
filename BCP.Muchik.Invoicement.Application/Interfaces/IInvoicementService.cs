using BCP.Muchik.Invoicement.Application.Dtos;

namespace BCP.Muchik.Invoicement.Application.Interfaces
{
    public interface IInvoicementService
    {
        ICollection<InvoiceDto> GetAllInvoives();
        CreateInvoiceDto CreateInvoice(CreateInvoiceDto invoiceDto);
    }
}
