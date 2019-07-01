using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShoppingListAPI.Entities.Database;

namespace ShoppingListAPI.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement(CategorySchema.Name)]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
    }
}
