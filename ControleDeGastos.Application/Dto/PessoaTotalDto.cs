

namespace ControleDeGastos.Application.Dto;

public class PessoaTotalDto
{
    public List<PessoaGeralDto> Pessoas { get; set; } = [];
    public decimal TotalReceitasGeral { get; set; }
    public decimal TotalDespesasGeral { get; set; }
    public decimal SaldoLiquidoGeral { get; set; }
}
