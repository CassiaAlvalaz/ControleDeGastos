
namespace ControleDeGastos.Application.Dto;

public class PessoaGeralDto : ComumDto
{
    public required string Nome { get; set; }
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public decimal Saldo { get; set; }
}
