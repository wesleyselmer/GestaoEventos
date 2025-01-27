using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FamiliaController : ControllerBase
{
    private readonly FamiliaServices _familiaServices;

    public FamiliaController(FamiliaServices familiaServices)
    {
        _familiaServices = familiaServices;
    }


    [HttpGet]
    public async Task<List<Familia>> GetFamilias() =>
        await _familiaServices.GetFamiliasAsync();


    [HttpGet("{id:length(24)}", Name = "GetFamilia")]
    public async Task<Familia> GetFamilia(string id) =>
        await _familiaServices.GetFamiliaAsync(id);


    [HttpPost]
    public async Task<Familia> CriarFamilia(Familia familia)
    {
        await _familiaServices.CriarFamiliaAsync(familia);
        return familia;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarFamilia(string id, Familia familia)
    {
       if (id != familia.Id)
       {
           return BadRequest("Familia ID incorreto");
        }

        var familiaAtual = await _familiaServices.GetFamiliaAsync(id);
        if(familiaAtual == null)
        {
            return NotFound();
        }

        familia.Id = familiaAtual.Id;

        await _familiaServices.AtualizarFamiliaAsync(id, familia);
        return Ok(familia);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverFamilia(string id)
    {
        await _familiaServices.RemoverFamiliaAsync(id);
    }
}

