using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers;

/// <summary>
/// Controller responsável por disponibilizar os endpoints de gerenciamento
/// da entidade Pessoa, permitindo operações de cadastro, edição, exclusão,
/// consulta individual, listagem geral e consulta de totais.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PessoaController : Controller
{
    private readonly IPessoaApplication _iPessoa;
    public PessoaController(IPessoaApplication iPessoa)
    {
        _iPessoa = iPessoa;
    }

    [HttpPost("AdicionarPessoas")]
    public async Task<ActionResult<PessoaDto>> AdicionarPessoa(PessoaDto pessoaDto)
    {
        PessoaDto pessoa = await _iPessoa.AdicionarPessoa(pessoaDto);
        return Ok(pessoa);
    }

    [HttpPut("EditarPessoas")]
    public async Task<ActionResult<PessoaDto>> EditarPessoa(int id, PessoaDto pessoaDto)
    {
        PessoaDto pessoa = await _iPessoa.EditarPessoa(id, pessoaDto);
        return Ok(pessoa);
    }

    [HttpDelete("ExcluirPessoas/{idPessoa}")]
    public async Task<ActionResult<PessoaDto>> ExcluiPessoa(int idPessoa)
    {
        bool excluir = await _iPessoa.ExcluirPessoa(idPessoa);

        if (!excluir)
            return NotFound("Pessoa não existe no banco de dados.");

        return NoContent();
    }

    [HttpGet("ListarPessoas")]
    public async Task<ActionResult<List<PessoaDto>>> ListarPessoas()
    {
        List<PessoaDto> pessoas = await _iPessoa.ListarPessoas();
        return Ok(pessoas);
    }

    [HttpGet("ListarPessoasPorId/{idPessoa}")]
    public async Task<ActionResult<PessoaDto>> ListarPessoasPorId(int idPessoa)
    {
        PessoaDto pessoa = await _iPessoa.ListaPessoaPorId(idPessoa);
        return Ok(pessoa);
    }

    [HttpGet("ListarPessoasPorTotais")]
    public async Task<ActionResult<PessoaTotalDto>> ListarPessoasPorTotais()
    {
        var resultado = await _iPessoa.ListarPessoasPorTotais();
        return Ok(resultado);
    }
}

