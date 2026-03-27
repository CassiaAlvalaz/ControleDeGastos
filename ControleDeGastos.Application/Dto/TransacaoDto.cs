using ControleDeGastos.Domain.Enum;

namespace ControleDeGastos.Application.Dto;

public class TransacaoDto : ComumDto
{
    public required string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoEnum Tipo { get; set; }
    public int IdCategoria { get; set; }
    public int IdPessoa { get; set; }
}
