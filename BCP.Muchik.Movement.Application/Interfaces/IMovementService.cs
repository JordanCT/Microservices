
using BCP.Muchik.Movement.Application.Dtos;

namespace BCP.Muchik.Movement.Application.Interfaces
{
    public interface IMovementService
    {
        IEnumerable<TransactionDto> GetAllTransactionsFromInvoice(int invoiceId);
        Task<bool> RegisterTransactionAsync(RegisterTransactionDto registerTransactionDto);
    }
}
