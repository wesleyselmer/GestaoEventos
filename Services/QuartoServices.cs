using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class QuartoServices
{
    private readonly IMongoCollection<Quarto> _quartoCollection;

    public QuartoServices(IOptions<GestaoeventosDatabaseSettings> quartoServices)
    {
        var mongoClient = new MongoClient(quartoServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(quartoServices.Value.DatabaseName);
        _quartoCollection = database.GetCollection<Quarto>(quartoServices.Value.QuartoCollectionName);
    }

    public async Task<List<Quarto>> GetQuartosAsync() =>
        await _quartoCollection.Find(quarto => true).ToListAsync();

    public async Task<Quarto> GetQuartoAsync(string id) =>
        await _quartoCollection.Find(quarto => quarto.Id == id).FirstOrDefaultAsync();

    public async Task CriarQuartoAsync(Quarto quarto) =>
        await _quartoCollection.InsertOneAsync(quarto);

    public async Task AtualizarQuartoAsync(string id, Quarto quarto) =>
        await _quartoCollection.ReplaceOneAsync(p => p.Id == id, quarto);

    public async Task RemoverQuartoAsync(string id) =>
        await _quartoCollection.DeleteOneAsync(quarto => quarto.Id == id);
}