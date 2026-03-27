using ControleDeGastos.Application.Dto;

namespace ControleDeGastos.Application.Interface;

public interface ITransacaoApplication
{
    Task<TransacaoDto> AdicionarTransacao(TransacaoDto transacao);
    Task<List<TransacaoDto>> ListarTransacoes();
}
