using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class CampoServices
{
    private readonly IMongoCollection<Campo> _campoCollection;

    public CampoServices(IOptions<GestaoeventosDatabaseSettings> campoServices)
    {
        var mongoClient = new MongoClient(campoServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(campoServices.Value.DatabaseName);
        _campoCollection = database.GetCollection<Campo>(campoServices.Value.CampoCollectionName);
    }

    public async Task<List<Campo>> GetCamposAsync() =>
        await _campoCollection.Find(campo => true).ToListAsync();

    public async Task<Campo> GetCampoAsync(string id) =>
        await _campoCollection.Find(campo => campo.Id == id).FirstOrDefaultAsync();

    public async Task CriarCampoAsync(Campo campo) =>
        await _campoCollection.InsertOneAsync(campo);

    public async Task AtualizarCampoAsync(string id, Campo campo) =>
        await _campoCollection.ReplaceOneAsync(p => p.Id == id, campo);

    public async Task RemoverCampoAsync(string id) =>
        await _campoCollection.DeleteOneAsync(campo => campo.Id == id);
}