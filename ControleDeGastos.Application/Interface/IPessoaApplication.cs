using ControleDeGastos.Application.Dto;

namespace ControleDeGastos.Application.Interface;

public interface IPessoaApplication
{
    Task<PessoaDto> AdicionarPessoa(PessoaDto pessoa);
    Task<PessoaDto> EditarPessoa(int id, PessoaDto pessoa);
    Task<bool> ExcluirPessoa(int id);
    Task<List<PessoaDto>> ListarPessoas();
    Task<PessoaDto> ListaPessoaPorId(int id);
    Task<PessoaTotalDto> ListarPessoasPorTotais();
}
