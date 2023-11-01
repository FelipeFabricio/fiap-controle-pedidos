using AutoMapper;
using Core.Entities;
using Core.Interfaces.Infra.Database;
using Infra.Database.MySql.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySql.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ControlePedidosContext _context;
    private readonly IMapper _mapper;

    public ClienteRepository(ControlePedidosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Cliente> ObtemTodosClientes()
    {
        var clientes = _context.Clientes.AsNoTracking().AsEnumerable();
        return _mapper.Map<IEnumerable<Cliente>>(clientes);
    }

    public Cliente ObtemClientePorId(Guid id)
    {
        var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return _mapper.Map<Cliente>(cliente);
    }
    
    public Cliente AdicionaCliente(Cliente cliente)
    {
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Clientes.Add(clienteInfra);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return _mapper.Map<Cliente>(clienteInfra);
    }

    public void AtualizaCliente(Cliente cliente)
    {
        var clienteContext = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == cliente.Id);
        if (clienteContext == null)
            throw new Exception("Cliente não encontrado");
        
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Entry(clienteInfra).State = EntityState.Modified;
        _context.SaveChanges();
        _context.ChangeTracker.Clear();

    }

    public void RemoveCliente(Guid id)
    {
        var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (cliente == null)
            throw new Exception("Cliente não encontrado");
        
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Clientes.Remove(clienteInfra);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}