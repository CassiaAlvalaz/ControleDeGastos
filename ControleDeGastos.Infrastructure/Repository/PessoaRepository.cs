using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;
using ControleDeGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.Repositoty;

/// <summary>
/// Classe responsável pelas operações de acesso aos dados da entidade Pessoa.
/// </summary>
public class PessoaRepository : IPessoa
{
    private readonly AppDbContext _context;
    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> AdicionarPessoa(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
        await _context.SaveChangesAsync();

        return pessoa;
    }

    public async Task<Pessoa> EditarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Update(pessoa);
        await _context.SaveChangesAsync();

        return pessoa;
    }

    public async Task<bool> ExcluirPessoa(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        _context.Remove(pessoa);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Pessoa> ListaPessoaPorId(int id)
    {
        return await _context.Pessoas.FirstOrDefaultAsync(pessoas => pessoas.Id == id);
    }

    public async Task<List<Pessoa>> ListarPessoas()
    {
        return await _context.Pessoas.ToListAsync();
    }
}
