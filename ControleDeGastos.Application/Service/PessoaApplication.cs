using ControleDeGastos.Application.Dto;
using ControleDeGastos.Application.Interface;
using ControleDeGastos.Domain.Entidades;
using ControleDeGastos.Domain.Interface;

namespace ControleDeGastos.Application.Service;

/// <summary>
/// Classe responsável pelas operações da entidade Pessoa na camada de aplicação.
/// </summary>
public class PessoaApplication : IPessoaApplication
{
    private readonly IPessoa _pessoaRepository;
    private readonly ITransacao _transacaoRepository;

    public PessoaApplication(IPessoa pessoaRepository, ITransacao transacaoRepository)
    {
        _pessoaRepository = pessoaRepository;
        _transacaoRepository = transacaoRepository;
    }

    public async Task<PessoaDto> AdicionarPessoa(PessoaDto pessoaDto)
    {
        try
        {
            Pessoa pessoa = await _pessoaRepository.AdicionarPessoa(new Pessoa
            {
                Nome = pessoaDto.Nome,
                Idade = pessoaDto.Idade
            });

            return new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao cadastrar pessoas.", ex);
        }
    }

    public async Task<PessoaDto> EditarPessoa(int id, PessoaDto pessoaDto)
    {
        try
        {
            var pessoa = await _pessoaRepository.ListaPessoaPorId(id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada no banco de dados.");

            pessoa.Nome = pessoaDto.Nome;
            pessoa.Idade = pessoaDto.Idade;

            pessoa = await _pessoaRepository.EditarPessoa(pessoa);

            return new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao editar pessoas.", ex);
        }
    }

    public Task<bool> ExcluirPessoa(int id)
    {
        try
        {
           return _pessoaRepository.ExcluirPessoa(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir pessoas.", ex);
        }
    }

    public async Task<PessoaDto> ListaPessoaPorId(int id)
    {
        try
        {
            Pessoa pessoa = await _pessoaRepository.ListaPessoaPorId(id);

            return new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar pessoas cadastradas por Id.", ex);
        }
    }

    public async Task<List<PessoaDto>> ListarPessoas()
    {
        try
        {
            List<Pessoa> pessoas = await _pessoaRepository.ListarPessoas();

            return pessoas.Select(pessoa => new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar pessoas cadastradas.", ex);
        }
    }

    public async Task<PessoaTotalDto> ListarPessoasPorTotais()
    {
        try
        {
            List<Pessoa> pessoas = await _pessoaRepository.ListarPessoas();
            List<Transacoes> transacoes = await _transacaoRepository.ListarTransacoes();

            var pessoasGeral = pessoas.Select(pessoa =>
            {
                var transacoesPessoa = transacoes.Where(t => t.IdPessoa == pessoa.Id).ToList();

                decimal totalReceitas = transacoesPessoa
                    .Where(t => t.Tipo == Domain.Enum.TipoEnum.Receita)
                    .Sum(t => t.Valor);

                decimal totalDespesas = transacoesPessoa
                    .Where(t => t.Tipo == Domain.Enum.TipoEnum.Despesa)
                    .Sum(t => t.Valor);

                return new PessoaGeralDto
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    TotalReceitas = totalReceitas,
                    TotalDespesas = totalDespesas,
                    Saldo = totalReceitas - totalDespesas
                };
            }).ToList();

            decimal totalReceitasGeral = pessoasGeral.Sum(p => p.TotalReceitas);
            decimal totalDespesasGeral = pessoasGeral.Sum(p => p.TotalDespesas);

            return new PessoaTotalDto
            {
                Pessoas = pessoasGeral,
                TotalReceitasGeral = totalReceitasGeral,
                TotalDespesasGeral = totalDespesasGeral,
                SaldoLiquidoGeral = totalReceitasGeral - totalDespesasGeral
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar pessoas por totais.", ex);
        }
    }
}
