using AutoMapper;
using Core.Entities;
using Core.Interfaces.Infra.Database;
using Infra.Database.MySql.Context;

namespace Infra.Database.MySql.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly ControlePedidosContext _context;
    private readonly IMapper _mapper;

    public PedidoRepository(ControlePedidosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Pedido> ObtemPedidos()
    {
        var pedidos = _context.Pedidos.AsEnumerable();
        return _mapper.Map<IEnumerable<Pedido>>(pedidos);
    }

    public IEnumerable<Pedido> ObtemPedidosPorStatus(short statusPedido)
    {
        var pedidos = _context.Pedidos.Where(p => p.Status == statusPedido).AsEnumerable();
        return _mapper.Map<IEnumerable<Pedido>>(pedidos);
    }
}