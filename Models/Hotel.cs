using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Hotel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("nome")]
    public required string Nome { get; set; }

    [BsonElement("quartos")]
    public List<Quarto>? Quartos { get; set; }
}