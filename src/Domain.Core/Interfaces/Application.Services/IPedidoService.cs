using Core.Entities;
using Core.Enums;

namespace Core.Interfaces.Application.Services;

public interface IPedidoService
{
    IEnumerable<Pedido> ObtemPedidos();
    IEnumerable<Pedido> ObtemPedidosPorStatus(StatusPedido statusPedido);
}