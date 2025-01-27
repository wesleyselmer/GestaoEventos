using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly HotelServices _hotelServices;

    public HotelController(HotelServices hotelServices)
    {
        _hotelServices = hotelServices;
    }


    [HttpGet]
    public async Task<List<Hotel>> GetHotels() =>
        await _hotelServices.GetHotelsAsync();


    [HttpGet("{id:length(24)}", Name = "GetHotel")]
    public async Task<Hotel> GetHotel(string id) =>
        await _hotelServices.GetHotelAsync(id);


    [HttpPost]
    public async Task<Hotel> CriarHotel(Hotel hotel)
    {
        await _hotelServices.CriarHotelAsync(hotel);
        return hotel;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarHotel(string id, Hotel hotel)
    {
       if (id != hotel.Id)
       {
           return BadRequest("Hotel ID incorreto");
        }

        var hotelAtual = await _hotelServices.GetHotelAsync(id);
        if(hotelAtual == null)
        {
            return NotFound();
        }

        hotel.Id = hotelAtual.Id;

        await _hotelServices.AtualizarHotelAsync(id, hotel);
        return Ok(hotel);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverHotel(string id)
    {
        await _hotelServices.RemoverHotelAsync(id);
    }
}

