using ControleDeGastos.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.Domain.Entidades;

/// <summary>
/// Classe responsável por armazenar as propriedades da entidade Categoria.
/// A string Descricao tem como definição tamanho máximo 400 em banco de dados.
/// A finalidade é vinculada a uma lista de Enums.
/// Herda da classe Comum a propriedade Id.
/// Lista de transações vinculadas a esta categoria.
/// Exemplo: Alimentação, Transporte, Salário, Lazer.
/// </summary>
public class Categoria : Comum
{
    [MaxLength(400)]
    public required string Descricao { get; set; }
    public FinalidadeEnum Finalidade { get; set; }
    public List<Transacoes> Transacoes { get; set; } = [];
}
