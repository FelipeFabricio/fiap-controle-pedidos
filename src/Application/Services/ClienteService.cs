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
    
    public Cliente ObtemClientePorId(Guid id)
    {
        return _clienteRepository.ObtemClientePorId(id);
    }
    
    public Cliente AdicionaCliente(Cliente cliente)
    {
        return _clienteRepository.AdicionaCliente(cliente);
    }
    
    public void AtualizaCliente(Cliente cliente)
    {
        _clienteRepository.AtualizaCliente(cliente);
    }
    
    public void RemoveCliente(Guid id)
    {
        _clienteRepository.RemoveCliente(id);
    }
}