using Core.Entities;

namespace Core.Interfaces.Infra.Database;

public interface IClienteRepository
{
    Cliente ObtemClientePorId(Guid id);
    IEnumerable<Cliente> ObtemTodosClientes();
    Cliente AdicionaCliente(Cliente cliente);
    void AtualizaCliente(Cliente cliente);
    void RemoveCliente(Guid id);
}