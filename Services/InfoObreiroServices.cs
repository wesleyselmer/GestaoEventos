using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class InfoObreiroServices
{
    private readonly IMongoCollection<InfoObreiro> _infoObreiroCollection;

    public InfoObreiroServices(IOptions<GestaoeventosDatabaseSettings> infoObreiroServices)
    {
        var mongoClient = new MongoClient(infoObreiroServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(infoObreiroServices.Value.DatabaseName);
        _infoObreiroCollection = database.GetCollection<InfoObreiro>(infoObreiroServices.Value.InfoObreiroCollectionName);
    }

    public async Task<List<InfoObreiro>> GetInfoObreirosAsync() =>
        await _infoObreiroCollection.Find(infoObreiro => true).ToListAsync();

    public async Task<InfoObreiro> GetInfoObreiroAsync(string id) =>
        await _infoObreiroCollection.Find(infoObreiro => infoObreiro.Id == id).FirstOrDefaultAsync();

    public async Task CriarInfoObreiroAsync(InfoObreiro infoObreiro) =>
        await _infoObreiroCollection.InsertOneAsync(infoObreiro);

    public async Task AtualizarInfoObreiroAsync(string id, InfoObreiro infoObreiro) =>
        await _infoObreiroCollection.ReplaceOneAsync(p => p.Id == id, infoObreiro);

    public async Task RemoverInfoObreiroAsync(string id) =>
        await _infoObreiroCollection.DeleteOneAsync(infoObreiro => infoObreiro.Id == id);
}