using ControleDeGastos.Domain.Entidades;

namespace ControleDeGastos.Domain.Interface;

/// <summary>
/// Define o contrato para manipulação e consulta de pessoas no domínio.
/// </summary>
public interface IPessoa
{
    Task<Pessoa> AdicionarPessoa(Pessoa pessoa);
    Task<Pessoa> EditarPessoa(Pessoa pessoa);
    Task<bool> ExcluirPessoa(int id);
    Task<List<Pessoa>> ListarPessoas();
    Task<Pessoa> ListaPessoaPorId(int id);
}
 