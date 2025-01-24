using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PessoaController: ControllerBase
{
    private readonly PessoaServices _pessoaServices;

    public PessoaController(PessoaServices pessoaServices)
    {
        _pessoaServices = pessoaServices;
    }

    [HttpGet]
    public async Task<List<Pessoa>> GetPessoas() =>
        await _pessoaServices.GetPessoasAsync();

    [HttpGet("{id}")]
    public async Task<Pessoa> GetPessoa(string id) =>
        await _pessoaServices.GetPessoaAsync(id);
    
    [HttpPost]
    public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
    {
        await _pessoaServices.CriarPessoaAsync(pessoa);
        return pessoa;
    }

    [HttpPut("{id}")]
    public async Task<Pessoa> AtualizarPessoa(string id, Pessoa pessoa)
    {
        await _pessoaServices.AtualizarPessoaAsync(id, pessoa);
        return pessoa;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPessoa(string id)
    {
        await _pessoaServices.RemoverPessoaAsync(id);
        return NoContent();
    }
}

