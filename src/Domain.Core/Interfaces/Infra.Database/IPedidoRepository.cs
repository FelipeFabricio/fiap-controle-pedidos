using Core.Entities;
using Core.Enums;

namespace Core.Interfaces.Infra.Database;

public interface IPedidoRepository
{
    IEnumerable<Pedido> ObtemPedidos();
    IEnumerable<Pedido> ObtemPedidosPorStatus(StatusPedido statusPedido);
}