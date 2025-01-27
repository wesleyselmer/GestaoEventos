using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class EventoServices
{
    private readonly IMongoCollection<Evento> _eventoCollection;

    public EventoServices(IOptions<GestaoeventosDatabaseSettings> eventoServices)
    {
        var mongoClient = new MongoClient(eventoServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(eventoServices.Value.DatabaseName);
        _eventoCollection = database.GetCollection<Evento>(eventoServices.Value.EventoCollectionName);
    }

    public async Task<List<Evento>> GetEventosAsync() =>
        await _eventoCollection.Find(evento => true).ToListAsync();

    public async Task<Evento> GetEventoAsync(string id) =>
        await _eventoCollection.Find(evento => evento.Id == id).FirstOrDefaultAsync();

    public async Task CriarEventoAsync(Evento evento) =>
        await _eventoCollection.InsertOneAsync(evento);

    public async Task AtualizarEventoAsync(string id, Evento evento) =>
        await _eventoCollection.ReplaceOneAsync(p => p.Id == id, evento);

    public async Task RemoverEventoAsync(string id) =>
        await _eventoCollection.DeleteOneAsync(evento => evento.Id == id);
}