using BCP.Muchik.Movement.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace BCP.Muchik.Movement.Infrastructure.Configurations
{
    public class TransactionEntityTypeConfiguration
    {
        public TransactionEntityTypeConfiguration()
        {
            BsonClassMap.RegisterClassMap<Transaction>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.SetIgnoreExtraElements(true);
                cm.GetMemberMap(c => c.InvoiceId)
                    .SetSerializer(new Int32Serializer(BsonType.Int32))
                    .SetElementName("id_invoice");
                cm.GetMemberMap(c => c.Amount)
                    .SetSerializer(new DecimalSerializer(BsonType.Decimal128))
                    .SetElementName("amount");
                cm.GetMemberMap(c => c.Date)
                    .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                    .SetElementName("date");
            });
        }
    }
}
