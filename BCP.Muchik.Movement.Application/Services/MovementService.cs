using AutoMapper;
using BCP.Muchik.Movement.Application.Dtos;
using BCP.Muchik.Movement.Application.Interfaces;
using BCP.Muchik.Movement.Domain.Entities;
using BCP.Muchik.Movement.Domain.Interfaces;

namespace BCP.Muchik.Movement.Application.Services
{
    public class MovementService : IMovementService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public MovementService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetAllTransactionsFromInvoice(int invoiceId)
        {
            var transactions = _transactionRepository.Query(x => x.InvoiceId == invoiceId);
            var transactionsDto = _mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return transactionsDto;
        }

        public async Task<bool> RegisterTransactionAsync(RegisterTransactionDto registerTransactionDto)
        {
            var transaction = _mapper.Map<Transaction>(registerTransactionDto);
            await _transactionRepository.Add(transaction);
            return await Task.FromResult(true);
        }
    }
}
