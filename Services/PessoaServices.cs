using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class PessoaServices
{
    private readonly IMongoCollection<Pessoa> _pessoaCollection;

    public PessoaServices(IOptions<GestaoeventosDatabaseSettings> pessoaServices)
    {
        var mongoClient = new MongoClient(pessoaServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(pessoaServices.Value.DatabaseName);
        _pessoaCollection = database.GetCollection<Pessoa>(pessoaServices.Value.PessoaCollectionName);
    }

    public async Task<List<Pessoa>> GetPessoasAsync() =>
        await _pessoaCollection.Find(pessoa => true).ToListAsync();

    public async Task<Pessoa> GetPessoaAsync(string id) =>
        await _pessoaCollection.Find(pessoa => pessoa.Id == id).FirstOrDefaultAsync();

    public async Task CriarPessoaAsync(Pessoa pessoa) =>
        await _pessoaCollection.InsertOneAsync(pessoa);
    
    public async Task AtualizarPessoaAsync(string id, Pessoa pessoa) =>
        await _pessoaCollection.ReplaceOneAsync(p => p.Id == id, pessoa);
    
    public async Task RemoverPessoaAsync(string id) =>
        await _pessoaCollection.DeleteOneAsync(pessoa => pessoa.Id == id);
}