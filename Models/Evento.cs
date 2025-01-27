using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Evento
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("nome")]
    public required string Nome { get; set; }

    [BsonElement("dataInicio")]
    public DateOnly DataInicio { get; set; }

    [BsonElement("dataFim")]
    public DateOnly DataFim { get; set; }
}