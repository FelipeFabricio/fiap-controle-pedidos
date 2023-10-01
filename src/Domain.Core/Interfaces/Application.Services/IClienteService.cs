using Core.Entities;

namespace Core.Interfaces.Application.Services;

public interface IClienteService
{
    IEnumerable<Cliente> ObtemTodosClientes();
}