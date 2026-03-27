using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;

namespace ControleDeGastos.Application.Service;

/// <summary>
/// Classe responsável pelas operações da entidade Categoria na camada de aplicação.
/// </summary>
public class CategoriaApplication : ICategoriaApplication
{
    private readonly ICategoria _categoriaRepository;
    public CategoriaApplication(ICategoria categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<CategoriaDto> AdicionarCategoria(CategoriaDto categoriaDto)
    {
        try
        {
            Categoria categoria = await _categoriaRepository.AdicionarCategoria(new Categoria
            {
                Descricao = categoriaDto.Descricao,
                Finalidade = categoriaDto.Finalidade,

            });

            return new CategoriaDto
            {
                Descricao = categoria.Descricao,
                Finalidade = categoria.Finalidade
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao cadastrar categoria.", ex);
        }
    }

    public async Task<List<CategoriaDto>> ListarCategorias()
    {
        try
        {
            List<Categoria> categorias = await _categoriaRepository.ListarCategorias();

            return categorias.Select(categorias => new CategoriaDto
            {
                Id = categorias.Id,
                Descricao = categorias.Descricao,
                Finalidade = categorias.Finalidade,
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar categoria.", ex);
        }
    }

    public async Task<CategoriaDto> ListarCategoriasPorId(int id)
    {
        try
        {
            Categoria categoria = await _categoriaRepository.ListarCategoriaPorId(id);

            return new CategoriaDto
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao,
                Finalidade = categoria.Finalidade
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar categoria por id.", ex);
        }
    }
}
