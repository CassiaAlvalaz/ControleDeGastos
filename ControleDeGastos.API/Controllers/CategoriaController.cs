using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers;

/// <summary>
/// Controller responsável por disponibilizar os endpoints de gerenciamento
/// da entidade Categoria, permitindo operações de cadastro, listagem e consulta individual.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoriaController : Controller
{
    private readonly ICategoriaApplication _iCategoria;
    public CategoriaController(ICategoriaApplication iCategoria)
    {
        _iCategoria = iCategoria;
    }

    [HttpPost("AdicionarCategoria")]
    public async Task<ActionResult<CategoriaDto>> AdicionarCategoria(CategoriaDto categoriaDto)
    {
        CategoriaDto categoria = await _iCategoria.AdicionarCategoria(categoriaDto);
        return Ok(categoriaDto);
    }

    [HttpGet("ListarCategorias")]
    public async Task<ActionResult<List<CategoriaDto>>> ListarCategorias()
    {
        List<CategoriaDto> categorias = await _iCategoria.ListarCategorias();
        return Ok(categorias);
    }

    [HttpGet("ListarCategoriasPorId/{idCategoria}")]
    public async Task<ActionResult<CategoriaDto>> ListarCategoriasPorId(int idCategoria)
    {
        CategoriaDto categoria = await _iCategoria.ListarCategoriasPorId(idCategoria);
        return Ok(categoria);
    }
}

