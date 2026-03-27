using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;
using ControleDeGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.Repositoty;

/// <summary>
/// Classe responsável pelas operações de acesso aos dados da entidade Transacao.
/// </summary>
public class TransacoesRepository : ITransacao
{
    private readonly AppDbContext _context;
    public TransacoesRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Transacoes> AdicionarTransacao(Transacoes transacao)
    {
        await _context.Transacoes.AddAsync(transacao);
        await _context.SaveChangesAsync();

        return transacao;
    }

    public async Task<List<Transacoes>> ListarTransacoes()
    {
        return await _context.Transacoes.ToListAsync();
    }
}
