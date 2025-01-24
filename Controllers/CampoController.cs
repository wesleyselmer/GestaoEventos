using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CampoController : ControllerBase
{
    private readonly CampoServices _campoServices;

    public CampoController(CampoServices campoServices)
    {
        _campoServices = campoServices;
    }


    [HttpGet]
    public async Task<List<Campo>> GetCampos() =>
        await _campoServices.GetCamposAsync();


    [HttpGet("{id:length(24)}", Name = "GetCampo")]
    public async Task<Campo> GetCampo(string id) =>
        await _campoServices.GetCampoAsync(id);


    [HttpPost]
    public async Task<Campo> CriarCampo(Campo campo)
    {
        await _campoServices.CriarCampoAsync(campo);
        return campo;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarCampo(string id, Campo campo)
    {
       if (id != campo.Id)
       {
           return BadRequest("Campo ID incorreto");
        }

        var campoAtual = await _campoServices.GetCampoAsync(id);
        if(campoAtual == null)
        {
            return NotFound();
        }

        campo.Id = campoAtual.Id;

        await _campoServices.AtualizarCampoAsync(id, campo);
        return Ok(campo);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverCampo(string id)
    {
        await _campoServices.RemoverCampoAsync(id);
    }
}

