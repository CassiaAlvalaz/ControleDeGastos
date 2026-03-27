using ControleDeGastos.Domain.Enum;

namespace ControleDeGastos.Application.Dto;

public class CategoriaDto : ComumDto
{
    public required string Descricao { get; set; }
    public FinalidadeEnum Finalidade { get; set; }
}
