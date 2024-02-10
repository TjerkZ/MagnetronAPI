using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.DTO
{
    public class MagnetronBrand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string Name { get; set; }
    }
}
