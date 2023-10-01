using Application.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Interface.WebApi.Controllers;

public class ClienteController
{
    [HttpGet]
    public IEnumerable<ClienteDto> Get()
    {
        IEnumerable<ClienteDto> listaClientes = new ClienteDto[]
        {
            new ClienteDto
            {
                Id = Guid.NewGuid(),
                Nome = "João",
                CPF = "12345678900",
                Email = "email@gmail.com",
            },
            new ClienteDto
            {
                Id = Guid.NewGuid(),
                Nome = "Maria",
                CPF = "12345678900",
                Email = "email@gmail.com",
            }
        };
        
        return listaClientes;
    }
}