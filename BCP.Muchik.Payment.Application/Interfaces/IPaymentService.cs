using BCP.Muchik.Payment.Application.Dtos;

namespace BCP.Muchik.Payment.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> RegisterPayment(PayDto payDto);
    }
}
