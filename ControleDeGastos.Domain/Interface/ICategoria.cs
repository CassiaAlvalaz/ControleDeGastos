using ControleDeGastos.Domain.Entidades;

namespace ControleDeGastos.Domain.Interface;

/// <summary>
/// Define o contrato para manipulação e consulta de categorias no domínio.
/// </summary>
public interface ICategoria
{
    Task<Categoria> AdicionarCategoria(Categoria categoria);
    Task<List<Categoria>> ListarCategorias();
    Task<Categoria> ListarCategoriaPorId(int id);
}
