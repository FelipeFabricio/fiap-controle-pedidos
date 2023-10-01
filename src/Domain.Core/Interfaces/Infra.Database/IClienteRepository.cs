using Core.Entities;

namespace Core.Interfaces.Infra.Database;

public interface IClienteRepository
{
    IEnumerable<Cliente> ObtemTodosClientes();
}