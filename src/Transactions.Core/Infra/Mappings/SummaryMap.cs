using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Transactions.Core.Domain.Entities;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Transactions.Core.Infra.Mappings
{
    public class SummaryMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Summary>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.SetIsRootClass(true);

                map.MapCreator(map => new Summary(map.CustomerName, map.CustomerDocument, map.TransactionDescription, map.TransactionValue, map.TransactionDate));

                map.MapIdProperty(x => x.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
                map.IdMemberMap.SetSerializer(new StringSerializer().WithRepresentation(BsonType.ObjectId));

                map
                .MapMember(x => x.CustomerName)
                .SetElementName("customerName")
                .SetOrder(2)
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new StringSerializer(BsonType.String));

                map
                .MapMember(x => x.CustomerDocument)
                .SetElementName("customerDocument")
                .SetOrder(3)
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new StringSerializer(BsonType.String));

                map
                .MapMember(x => x.TransactionDescription)
                .SetElementName("transactionDescription")
                .SetOrder(4)
                .SetIgnoreIfNull(false)
                .SetIsRequired(true)
                .SetSerializer(new StringSerializer(BsonType.String));

                map
                .MapMember(x => x.TransactionValue)
                .SetElementName("transactionValue")
                .SetOrder(5)
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new DecimalSerializer(BsonType.Decimal128));

                map
                .MapMember(x => x.TransactionDate)
                .SetElementName("transactionDate")
                .SetOrder(6)
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));
            });
        }
    }
}
