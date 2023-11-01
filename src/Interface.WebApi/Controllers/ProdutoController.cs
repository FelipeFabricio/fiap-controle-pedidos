using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interface.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoService produtoService, IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ProdutoDto> GetProduto(Guid id)
    {
        var produto = _produtoService.ObtemProdutoPorId(id);
        if (produto is null)
            return NotFound();
        
        return Ok(produto);
    }
    
    [HttpGet()]
    public ActionResult<IEnumerable<ProdutoDto>> GetProdutos()
    {
        var produtos = _produtoService.ObtemTodosProdutos();
        if (!produtos.Any()) 
            return NotFound();
        
        return Ok(produtos);
    }

    [HttpGet("{categoria:int}")]
    public ActionResult<IEnumerable<ProdutoDto>> GetProdutoPorCategoria(short categoria)
    {
        var produtos = _produtoService.ObtemProdutosPorCategoria(categoria);
        if (produtos is null)
            return NotFound();
        
        return Ok(produtos);
    }

    [HttpPost]
    public ActionResult<ProdutoDto> CreateProduto([FromBody]ProdutoDto produto)
    {
        var produtoCadastrado = _produtoService.AdicionaProduto(_mapper.Map<Produto>(produto));
        return Ok(_mapper.Map<ProdutoDto>(produtoCadastrado));
    }

    [HttpPut("{id:Guid}")]
    public IActionResult UpdateProduto(Guid id, ProdutoDto produto)
    {
        if (id != produto.Id)
            return BadRequest();
        
        var produtoDomain = _mapper.Map<Produto>(produto);
        _produtoService.AtualizaProduto(produtoDomain);
        
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult DeleteProduto(Guid id)
    {
        _produtoService.RemoveProduto(id);
        return NoContent();
    }
}