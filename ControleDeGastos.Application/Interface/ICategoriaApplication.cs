using ControleDeGastos.Application.Dto;

namespace ControleDeGastos.Application.Interface;

public interface ICategoriaApplication 
{
    Task<CategoriaDto> AdicionarCategoria(CategoriaDto categoria);
    Task<List<CategoriaDto>> ListarCategorias();
    Task<CategoriaDto> ListarCategoriasPorId(int id);
}
