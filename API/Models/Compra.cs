using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{    
    public class Compra
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public required string Produto { get; set; }
        public bool isChecked { get; set; }
    }
}
