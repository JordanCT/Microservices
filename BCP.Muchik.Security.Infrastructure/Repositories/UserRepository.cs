using BCP.Muchik.Security.Domain.Entities;
using BCP.Muchik.Security.Domain.Interfaces;
using BCP.Muchik.Security.Infrastructure.Context;

namespace BCP.Muchik.Security.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
