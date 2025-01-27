using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InfoObreiroController : ControllerBase
{
    private readonly InfoObreiroServices _infoObreiroServices;

    public InfoObreiroController(InfoObreiroServices infoObreiroServices)
    {
        _infoObreiroServices = infoObreiroServices;
    }


    [HttpGet]
    public async Task<List<InfoObreiro>> GetInfoObreiros() =>
        await _infoObreiroServices.GetInfoObreirosAsync();


    [HttpGet("{id:length(24)}", Name = "GetInfoObreiro")]
    public async Task<InfoObreiro> GetInfoObreiro(string id) =>
        await _infoObreiroServices.GetInfoObreiroAsync(id);


    [HttpPost]
    public async Task<InfoObreiro> CriarInfoObreiro(InfoObreiro infoObreiro)
    {
        await _infoObreiroServices.CriarInfoObreiroAsync(infoObreiro);
        return infoObreiro;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> AtualizarInfoObreiro(string id, InfoObreiro infoObreiro)
    {
       if (id != infoObreiro.Id)
       {
           return BadRequest("InfoObreiro ID incorreto");
        }

        var infoObreiroAtual = await _infoObreiroServices.GetInfoObreiroAsync(id);
        if(infoObreiroAtual == null)
        {
            return NotFound();
        }

        infoObreiro.Id = infoObreiroAtual.Id;

        await _infoObreiroServices.AtualizarInfoObreiroAsync(id, infoObreiro);
        return Ok(infoObreiro);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task RemoverInfoObreiro(string id)
    {
        await _infoObreiroServices.RemoverInfoObreiroAsync(id);
    }
}

