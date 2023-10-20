using System.Linq.Expressions;

namespace BCP.Muchik.Movement.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
