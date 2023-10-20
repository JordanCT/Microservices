using BCP.Muchik.Movement.Domain.Interfaces;
using BCP.Muchik.Movement.Infrastructure.Context;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace BCP.Muchik.Movement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MovementContext _context;
        protected readonly IMongoCollection<T> _dbCollection;
        public GenericRepository(MovementContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<T>(typeof(T).Name.ToLower());
        }
        public async Task Add(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var all = await _dbCollection.FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbCollection.AsQueryable().Where(predicate.Compile()).ToList();
        }
    }
}
