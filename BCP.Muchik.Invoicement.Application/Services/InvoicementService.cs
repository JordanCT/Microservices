using AutoMapper;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Application.Interfaces;
using BCP.Muchik.Invoicement.Domain.Entities;
using BCP.Muchik.Invoicement.Domain.Interfaces;

namespace BCP.Muchik.Invoicement.Application.Services
{
    public class InvoicementService : IInvoicementService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoicementService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public CreateInvoiceDto CreateInvoice(CreateInvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            _invoiceRepository.Add(invoice);
            _invoiceRepository.Save();
            return invoiceDto;
        }

        public ICollection<InvoiceDto> GetAllInvoives()
        {
            var invoices = _invoiceRepository.List();
            var invoicesDto = _mapper.Map<ICollection<InvoiceDto>>(invoices);
            return invoicesDto;
        }
    }
}
