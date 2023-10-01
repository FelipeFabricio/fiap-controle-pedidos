using Core.Entities;
using Core.Interfaces.Infra.Database;
using Infra.Database.MySql.Context;

namespace Infra.Database.MySql.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ControlePedidosContext _context;

    public ClienteRepository(ControlePedidosContext context)
    {
        _context = context;
    }

    public IEnumerable<Cliente> ObtemTodosClientes()
    {
        IEnumerable<DataModels.Cliente> clientes = _context.Clientes.AsEnumerable();
        
        //TODO: Implementar AutoMapper ou outra forma de mapeamento. Precisamos retornar uma lista de entidades, não de DataModels.
        return new List<Cliente>();
    }
}