using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class HotelServices
{
    private readonly IMongoCollection<Hotel> _hotelCollection;

    public HotelServices(IOptions<GestaoeventosDatabaseSettings> hotelServices)
    {
        var mongoClient = new MongoClient(hotelServices.Value.ConnectionString);
        var database = mongoClient.GetDatabase(hotelServices.Value.DatabaseName);
        _hotelCollection = database.GetCollection<Hotel>(hotelServices.Value.HotelCollectionName);
    }

    public async Task<List<Hotel>> GetHotelsAsync() =>
        await _hotelCollection.Find(hotel => true).ToListAsync();

    public async Task<Hotel> GetHotelAsync(string id) =>
        await _hotelCollection.Find(hotel => hotel.Id == id).FirstOrDefaultAsync();

    public async Task CriarHotelAsync(Hotel hotel) =>
        await _hotelCollection.InsertOneAsync(hotel);

    public async Task AtualizarHotelAsync(string id, Hotel hotel) =>
        await _hotelCollection.ReplaceOneAsync(p => p.Id == id, hotel);

    public async Task RemoverHotelAsync(string id) =>
        await _hotelCollection.DeleteOneAsync(hotel => hotel.Id == id);
}