using Core.Entities;

namespace Core.Interfaces.Application.Services;

public interface IPedidoService
{
    IEnumerable<Pedido> ObtemPedidos();
    IEnumerable<Pedido> ObtemPedidosPorStatus(short statusPedido);
}