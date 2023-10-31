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
        var clientes = _context.Clientes.AsEnumerable();
        return _mapper.Map<IEnumerable<Cliente>>(clientes);
    }

    public Cliente ObtemClientePorId(Guid id)
    {
        var cliente = _context.Clientes.Find(id);
        return _mapper.Map<Cliente>(cliente);
    }
    
    public void AdicionaCliente(Cliente cliente)
    {
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Clientes.Add(clienteInfra);
        _context.SaveChanges();
    }

    public void AtualizaCliente(Cliente cliente)
    {
        var clienteContext = ObtemClientePorId(cliente.Id);
        if (clienteContext == null)
            throw new Exception("Cliente não encontrado");
        
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Entry(clienteInfra).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveCliente(Guid id)
    {
        var cliente = ObtemClientePorId(id);
        if (cliente == null)
            throw new Exception("Cliente não encontrado");
        
        var clienteInfra = _mapper.Map<DataModels.Cliente>(cliente);
        _context.Clientes.Remove(clienteInfra);
        _context.SaveChanges();
    }
}