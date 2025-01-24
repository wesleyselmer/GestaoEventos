using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Pessoa
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    [BsonElement("nome")]
    public required string Nome { get; set; }

    [BsonElement("cpf")]
    public required string CPF { get; set; }

    [BsonElement("dataNascimento")]
    public DateOnly DataNascimento { get; set; }

    [BsonElement("funcao")]
    public required string Funcao { get; set; }
}