using Core.Entities;

namespace Core.Interfaces.Infra.Database;

public interface IPedidoRepository
{
    IEnumerable<Pedido> ObtemPedidos();
    IEnumerable<Pedido> ObtemPedidosPorStatus(short statusPedido);
}