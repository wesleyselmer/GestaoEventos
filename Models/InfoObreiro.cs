using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class InfoObreiro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    [BsonElement("pessoaId")]
    public required string PessoaId { get; set; }

    [BsonElement("campoId")]
    public required string CampoId { get; set; }

    [BsonElement("tempoMinisterio")]
    public int? TempoMinisterio { get; set; }
}