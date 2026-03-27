using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers;

/// <summary>
/// Controller responsável por disponibilizar os endpoints de gerenciamento
/// da entidade Transacao, permitindo operações de cadastro e listagem geral.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransacaoController : Controller
{
    private readonly ITransacaoApplication _iTransacao;
    public TransacaoController(ITransacaoApplication iTransacao)
    {
        _iTransacao = iTransacao;
    }

    [HttpPost("AdicionarTransacao")]
    public async Task<ActionResult<TransacaoDto>> AdicionarTransacao(TransacaoDto transacaoDto)
    {
        TransacaoDto transacao = await _iTransacao.AdicionarTransacao(transacaoDto);
        return Ok(transacao);
    }

    [HttpGet("ListarTransacoes")]
    public async Task<ActionResult<List<TransacaoDto>>> ListarTransacoes()
    {
        List<TransacaoDto> transacoes = await _iTransacao.ListarTransacoes();
        return Ok(transacoes);
    }
}

