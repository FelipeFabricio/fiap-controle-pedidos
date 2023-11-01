using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interface.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;

    public ClienteController(IClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ClienteDto>> GetClientes()
    {
        var clientes = _clienteService.ObtemTodosClientes();
        if (!clientes.Any()) 
            return NotFound();
        
        return Ok(clientes);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ClienteDto> GetCliente(Guid id)
    {
        var cliente = _clienteService.ObtemClientePorId(id);
        if (cliente is null)
            return NotFound();
        
        return Ok(cliente);
    }

    [HttpPost]
    public ActionResult<ClienteDto> CreateCliente([FromBody]ClienteDto cliente)
    {
        var clienteCadastrado = _clienteService.AdicionaCliente(_mapper.Map<Cliente>(cliente));
        return Ok(_mapper.Map<ClienteDto>(clienteCadastrado));
    }

    [HttpPut("{id:Guid}")]
    public IActionResult UpdateCliente(Guid id, ClienteDto cliente)
    {
        if (id != cliente.Id)
            return BadRequest();
        
        var clienteDomain = _mapper.Map<Cliente>(cliente);
        _clienteService.AtualizaCliente(clienteDomain);
        
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult DeleteCliente(Guid id)
    {
        _clienteService.RemoveCliente(id);
        return NoContent();
    }
}