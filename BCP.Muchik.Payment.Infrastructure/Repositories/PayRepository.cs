using BCP.Muchik.Payment.Domain.Entities;
using BCP.Muchik.Payment.Domain.Interfaces;
using BCP.Muchik.Payment.Infrastructure.Context;

namespace BCP.Muchik.Payment.Infrastructure.Repositories
{
    public class PayRepository : GenericRepository<Pay>, IPayRepository
    {
        public PayRepository(PaymentContext context) : base(context)
        {
        }
    }
}
