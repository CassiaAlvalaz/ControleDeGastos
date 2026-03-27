using ControleDeGastos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.Data;

/// <summary>
/// Classe responsável pelo contexto de acesso ao banco de dados, 
/// criação das migrações e definições recebidas da Domain.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas {  get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Transacoes> Transacoes { get; set; }

}
