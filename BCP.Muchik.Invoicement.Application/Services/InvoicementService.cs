using AutoMapper;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Application.Interfaces;
using BCP.Muchik.Invoicement.Domain.Agregates;
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
        public InvoiceDto CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(createInvoiceDto);
            invoice.State = InvoiceStatus.Pending.Id;
            _invoiceRepository.Add(invoice);
            _invoiceRepository.Save();
            return _mapper.Map<InvoiceDto>(invoice);
        }
        public bool PayInvoice(PayInvoiceDto payInvoiceDto)
        {
            var invoiceForUpdate = _invoiceRepository.GetById(payInvoiceDto.Id);
            if (invoiceForUpdate.Amount <= payInvoiceDto.Amount) {
                invoiceForUpdate.State = InvoiceStatus.Paid.Id;
                _invoiceRepository.Update(invoiceForUpdate);
                return _invoiceRepository.Save();
            }
            return false;
        }

        public ICollection<InvoiceDto> GetAllInvoives()
        {
            var invoices = _invoiceRepository.List();
            var invoicesDto = _mapper.Map<ICollection<InvoiceDto>>(invoices);
            return invoicesDto;
        }
    }
}
