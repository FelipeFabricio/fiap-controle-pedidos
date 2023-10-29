﻿using Core.Entities;

namespace Core.Interfaces.Application.Services;

public interface IClienteService
{
    IEnumerable<Cliente> ObtemTodosClientes();
    Cliente ObtemClientePorId(Guid id);
    void AdicionaCliente(Cliente cliente);
    void AtualizaCliente(Cliente cliente);
    void RemoveCliente(Guid id);
}