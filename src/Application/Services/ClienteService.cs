using Core.Entities;
using Core.Interfaces.Application.Services;
using Core.Interfaces.Infra.Database;

namespace Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public IEnumerable<Cliente> ObtemTodosClientes()
    {
        return _clienteRepository.ObtemTodosClientes();
    }
}