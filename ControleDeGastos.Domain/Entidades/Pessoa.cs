using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.Domain.Entidades;

/// <summary>
/// Classe responsável por armazenar as propriedades da entidade Pessoa.
/// A string Nome tem como definição tamanho máximo 200 em banco de dados.
/// Herda da classe Comum a propriedade Id.
/// Lista de transações vinculadas a esta pessoa.
/// </summary>
public class Pessoa : Comum
{
    [MaxLength(200)]
    public required string Nome { get; set; }
    public int Idade { get; set; }
    public List<Transacoes> Transacoes { get; set; } = [];
}
