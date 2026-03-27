using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;

namespace ControleDeGastos.Application.Service;

/// <summary>
/// Classe responsável pelas operações da entidade Transacao na camada de aplicação.
/// </summary>
public class TransacaoApplication : ITransacaoApplication
{
    private readonly ITransacao _transacaoRepository;
    private readonly IPessoa _pessoaRepository;
    private readonly ICategoria _categoriaRepository;
    public TransacaoApplication(ITransacao transacaoRepository, IPessoa pessoaRepository, ICategoria categoriaRepository)
    {
        _transacaoRepository = transacaoRepository;
        _pessoaRepository = pessoaRepository;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<TransacaoDto> AdicionarTransacao(TransacaoDto transacaoDto)
    {
        Pessoa pessoa = await _pessoaRepository.ListaPessoaPorId(transacaoDto.IdPessoa);
        if (pessoa.Idade < 18 && transacaoDto.Tipo == Domain.Enum.TipoEnum.Receita)
            throw new Exception("Menores de 18 anos só podem ter despesas");

        Categoria categoria = await _categoriaRepository.ListarCategoriaPorId(transacaoDto.IdCategoria);
        if (categoria.Finalidade.ToString() != transacaoDto.Tipo.ToString())
            throw new Exception("O tipo de transacao deve ser da mesma finalidade que a categoria. \nReceita = receita. \nDespesa = despesa.");

        var transacao = await _transacaoRepository.AdicionarTransacao(new Transacoes
        {
            Descricao = transacaoDto.Descricao,
            Valor = transacaoDto.Valor,
            Tipo = transacaoDto.Tipo,
            IdCategoria = transacaoDto.IdCategoria,
            IdPessoa = transacaoDto.IdPessoa
        });

        return new TransacaoDto
        {
            Descricao = transacao.Descricao,
            Valor = transacao.Valor,
            Tipo = transacao.Tipo,
            IdCategoria = transacao.IdCategoria,
            IdPessoa = transacao.IdPessoa
        };
    }

    public async Task<List<TransacaoDto>> ListarTransacoes()
    {
        try
        {
            List<Transacoes> transacoes = await _transacaoRepository.ListarTransacoes();

            return transacoes.Select(transacoes => new TransacaoDto
            {
                Id = transacoes.Id,
                Descricao = transacoes.Descricao,
                Valor = transacoes.Valor,
                Tipo = transacoes.Tipo,
                IdCategoria = transacoes.IdCategoria,
                IdPessoa = transacoes.IdPessoa
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar transacoes.", ex);
        }
    }
}
