using AutoMapper;
using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Payment.Application.Dtos;
using BCP.Muchik.Payment.Application.Events;
using BCP.Muchik.Payment.Application.Interfaces;
using BCP.Muchik.Payment.Domain.Entities;
using BCP.Muchik.Payment.Domain.Interfaces;

namespace BCP.Muchik.Payment.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly IPayRepository _payRepository;

        public PaymentService(IMapper mapper, IEventBus eventBus, IPayRepository payRepository)
        {
            _mapper = mapper;
            _eventBus = eventBus;
            _payRepository = payRepository;
        }

        public async Task<bool> RegisterPayment(PayDto payDto)
        {
            var payment = _payRepository.Find(s => s.InvoiceId.Equals(payDto.InvoiceId)).FirstOrDefault();
            if (payment is not null)
            {
                payment.Amount += payDto.Amount;
                payment.Date = DateTime.Now;
                _payRepository.Update(payment);
            }
            else
            {
                payment = _mapper.Map<Pay>(payDto);
                _payRepository.Add(payment);
            }            
            var successUpsert = _payRepository.Save();
            if (successUpsert)
            {
                _eventBus.Publish(new InvoicePayEvent(payment.InvoiceId, payment.Amount));
                _eventBus.Publish(new TransactionConfirmEvent(payment.InvoiceId, payDto.Amount, payment.Date));
                return await Task.FromResult(true);
            }
            return successUpsert;
        }
    }
}
