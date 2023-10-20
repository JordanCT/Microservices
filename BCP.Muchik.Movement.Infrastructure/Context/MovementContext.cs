using BCP.Muchik.Movement.Infrastructure.Configurations;
using BCP.Muchik.Movement.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BCP.Muchik.Movement.Infrastructure.Context
{
    public class MovementContext
    {
        private IMongoDatabase _mongoDatabase { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MovementContext(IOptions<MongoSettings> configuration)
        {
            MapClasses();
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(configuration.Value.DatabaseName);            
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabase.GetCollection<T>(name);
        }
        private void MapClasses()
        {
            _ = new TransactionEntityTypeConfiguration();
        }
    }
}
