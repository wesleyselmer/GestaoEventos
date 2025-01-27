using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class QuartoController : ControllerBase
{
    private readonly QuartoServices _quartoServices;

    public QuartoController(QuartoServices quartoServices)
    {
        _quartoServices = quartoServices;
    }


    [HttpGet]
    public async Task<List<Quarto>> GetQuartos() =>
        await _quartoServices.GetQuartosAsync();


    [HttpGet("{id:length(24)}", Name = "GetQuarto")]
    public async Task<Quarto> GetQuarto(string id) =>
        await _quartoServices.GetQuartoAsync(id);


    [HttpPost]
    public async Task<Quarto> CriarQuarto(Quarto quarto)
    {
        await _quartoServices.CriarQuartoAsync(quarto);
        return quarto;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarQuarto(string id, Quarto quarto)
    {
       if (id != quarto.Id)
       {
           return BadRequest("Quarto ID incorreto");
        }

        var quartoAtual = await _quartoServices.GetQuartoAsync(id);
        if(quartoAtual == null)
        {
            return NotFound();
        }

        quarto.Id = quartoAtual.Id;

        await _quartoServices.AtualizarQuartoAsync(id, quarto);
        return Ok(quarto);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverQuarto(string id)
    {
        await _quartoServices.RemoverQuartoAsync(id);
    }
}

