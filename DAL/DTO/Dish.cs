using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.DTO
{
    public class Dish
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DishId { get; set; }
        public string? Name { get; set; }
        public List<Prep>? Preps { get; set; }
    }
}
