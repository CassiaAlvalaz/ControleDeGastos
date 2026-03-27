using ControleDeGastos.Domain.Entidades;

namespace ControleDeGastos.Domain.Interface;

/// <summary>
/// Define o contrato para manipulação e consulta de transações no domínio.
/// </summary>
public interface ITransacao
{
    Task<Transacoes> AdicionarTransacao(Transacoes transacao);
    Task<List<Transacoes>> ListarTransacoes();
}
