using Application.Dtos.Enums;

namespace Application.Dtos;

public sealed record  PedidoDto
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal Valor { get; set; }
    public StatusPedidoDto Status { get; set; }
    public ClienteDto ClienteDto { get; set; }
    public IEnumerable<ItemPedidoDto> ItensPedido { get; set; }
}
