using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;
using ControleDeGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.Repositoty;

/// <summary>
/// Classe responsável pelas operações de acesso aos dados da entidade Categoria.
/// </summary>
public class CategoriaRepository : ICategoria
{
    private readonly AppDbContext _context;
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> AdicionarCategoria(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<Categoria> ListarCategoriaPorId(int id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id);
    }

    public async Task<List<Categoria>> ListarCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }
}
