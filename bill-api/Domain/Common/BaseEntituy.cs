using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace bill_api.Domain.Common
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
