using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class FamiliaServices
{
    private readonly IMongoCollection<Familia> _familiaCollection;

    public FamiliaServices(IOptions<GestaoeventosDatabaseSettings> familiaServices)
    {
        var mongoClient = new MongoClient(familiaServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(familiaServices.Value.DatabaseName);
        _familiaCollection = database.GetCollection<Familia>(familiaServices.Value.FamiliaCollectionName);
    }

    public async Task<List<Familia>> GetFamiliasAsync() =>
        await _familiaCollection.Find(familia => true).ToListAsync();

    public async Task<Familia> GetFamiliaAsync(string id) =>
        await _familiaCollection.Find(familia => familia.Id == id).FirstOrDefaultAsync();

    public async Task CriarFamiliaAsync(Familia familia) =>
        await _familiaCollection.InsertOneAsync(familia);

    public async Task AtualizarFamiliaAsync(string id, Familia familia) =>
        await _familiaCollection.ReplaceOneAsync(p => p.Id == id, familia);

    public async Task RemoverFamiliaAsync(string id) =>
        await _familiaCollection.DeleteOneAsync(familia => familia.Id == id);
}