using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Campo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    [BsonElement("nome")]
    public required string Nome { get; set; }

    [BsonElement("sigla")]
    public required string Sigla { get; set; }
}