using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly EventoServices _eventoServices;

    public EventoController(EventoServices eventoServices)
    {
        _eventoServices = eventoServices;
    }


    [HttpGet]
    public async Task<List<Evento>> GetEventos() =>
        await _eventoServices.GetEventosAsync();


    [HttpGet("{id:length(24)}", Name = "GetEvento")]
    public async Task<Evento> GetEvento(string id) =>
        await _eventoServices.GetEventoAsync(id);


    [HttpPost]
    public async Task<Evento> CriarEvento(Evento evento)
    {
        await _eventoServices.CriarEventoAsync(evento);
        return evento;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarEvento(string id, Evento evento)
    {
       if (id != evento.Id)
       {
           return BadRequest("Evento ID incorreto");
        }

        var eventoAtual = await _eventoServices.GetEventoAsync(id);
        if(eventoAtual == null)
        {
            return NotFound();
        }

        evento.Id = eventoAtual.Id;

        await _eventoServices.AtualizarEventoAsync(id, evento);
        return Ok(evento);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverEvento(string id)
    {
        await _eventoServices.RemoverEventoAsync(id);
    }
}

