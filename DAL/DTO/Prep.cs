using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.DTO
{
    public class Prep
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PrepId { get; set; }
        public string? DishId { get; set; }
        public string? Mode { get; set; }
        public int? Watt { get; set; }
        public int? Temp { get; set; }
        public int? Rating { get; set; }
        public string? Notes { get; set; }
    }
}
