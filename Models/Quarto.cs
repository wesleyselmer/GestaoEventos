using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Quarto
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string? Id { get; set; }
   
    [BsonElement("tipo")]
    public required string Tipo { get; set; }

    [BsonElement("qtdeCasal")]
    public int? QuantidadeCasal { get; set; }

    [BsonElement("qtdeSolteiro")]
    public int? QuantidadeSolteiro { get; set; }

    [BsonElement("totalQuartos")]
    public int? TotalQuartos { get; set; }
}