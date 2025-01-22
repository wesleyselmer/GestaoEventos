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
    
    [HttpPost]
    public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
    {
        await _pessoaServices.CriarPessoaAsync(pessoa);
        return pessoa;
    }
}

