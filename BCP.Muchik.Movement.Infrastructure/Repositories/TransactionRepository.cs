using BCP.Muchik.Movement.Domain.Entities;
using BCP.Muchik.Movement.Domain.Interfaces;
using BCP.Muchik.Movement.Infrastructure.Context;

namespace BCP.Muchik.Movement.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(MovementContext context) : base(context)
        {
        }
    }
}
