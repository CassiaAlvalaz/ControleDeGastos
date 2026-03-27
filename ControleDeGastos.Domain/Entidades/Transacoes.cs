using ControleDeGastos.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastos.Domain.Entidades;

/// <summary>
/// Classe responsável por armazenar as propriedades da entidade Transacao.
/// A string Descricao tem como definição tamanho máximo 400 em banco de dados.
/// O Tipo é vinculada a uma lista de Enums.
/// Herda da classe Comum a propriedade Id.
/// Se é necessário IdPessoa e IdCategoria para vinculo do envio das informações.
/// Exemplo: Pagamento, Mercado.
/// </summary>
public class Transacoes : Comum
{
    [MaxLength(400)]
    public required string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoEnum Tipo { get; set; }
    public int IdCategoria { get; set; }
    [ForeignKey("IdCategoria")]
    public Categoria Categoria { get; set; }
    public int IdPessoa { get; set; }
    [ForeignKey("IdPessoa")]
    public Pessoa Pessoa { get; set; }
}
