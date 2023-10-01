using Core.Enums;

namespace Core.Entities;

public sealed record  Pedido
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal Valor { get; set; }
    public StatusPedido Status { get; set; }
    public Cliente Cliente { get; set; }
    public IEnumerable<ItemPedido> ItensPedido { get; set; }
}
