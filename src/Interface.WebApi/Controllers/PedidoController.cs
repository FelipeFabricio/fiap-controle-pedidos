using Application.Dtos;
using AutoMapper;
using Core.Interfaces.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interface.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    private readonly IMapper _mapper;

    public PedidoController(IMapper mapper, IPedidoService pedidoService)
    {
        _mapper = mapper;
        _pedidoService = pedidoService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<PedidoDto>> GetPedidos()
    {
        var pedidos = _pedidoService.ObtemPedidos();
        if (!pedidos.Any()) 
            return NotFound();
        
        return Ok(pedidos);
    }

    [HttpGet("{status}")]
    public ActionResult<IEnumerable<PedidoDto>> GetPedidosPorStatus(short status)
    {
        var pedidos = _pedidoService.ObtemPedidosPorStatus(status);
        if (!pedidos.Any()) 
            return NotFound();
        
        return Ok(pedidos);
    }
}