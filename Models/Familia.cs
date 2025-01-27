using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Familia
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("pessoaIdPai")]
    public string? PessoaIdPai { get; set; }

    [BsonElement("pessoaIdMae")]
    public string? PessoaIdMae { get; set; }

    [BsonElement("filhos")]
    public List<string>? Filhos { get; set; }
}