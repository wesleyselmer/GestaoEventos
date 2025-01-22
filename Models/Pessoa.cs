using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Pessoa
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Nome")]
    public string Nome { get; set; }

    [BsonElement("CPF")]
    public int CPF { get; set; }

    [BsonElement("DataNascimento")]
    public DateOnly DataNascimento { get; set; }

    [BsonElement("funcao")]
    public string Funcao { get; set; }

}