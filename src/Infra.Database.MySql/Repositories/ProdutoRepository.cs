using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Infra.Database;
using Infra.Database.MySql.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySql.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ControlePedidosContext _context;
    private readonly IMapper _mapper;

    public ProdutoRepository(ControlePedidosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Produto ObtemProdutoPorId(Guid id)
    {   
        var produto = _context.Produtos.Find(id);
        return _mapper.Map<Produto>(produto);
    }

    public Produto ObtemProdutoPorCategoria(CategoriaProduto categoria)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Categoria == categoria);
        return _mapper.Map<Produto>(produto);
    }

    public IEnumerable<Produto> ObtemTodosProdutos()
    {
        var produtos = _context.Produtos.AsEnumerable();
        return _mapper.Map<IEnumerable<Produto>>(produtos);
    }

    public void AdicionaProduto(Produto produto)
    {
        var produtoInfra = _mapper.Map<DataModels.Produto>(produto);
        _context.Produtos.Add(produtoInfra);
        _context.SaveChanges();
    }

    public void AtualizaProduto(Produto produto)
    {
        var produtoContext = ObtemProdutoPorId(produto.Id);
        if (produtoContext == null)
            throw new Exception("Produto não encontrado");
        
        var produtoInfra = _mapper.Map<DataModels.Produto>(produto);
        _context.Entry(produtoInfra).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveProduto(Guid id)
    {
        var produtoContext = ObtemProdutoPorId(id);
        if (produtoContext == null)
            throw new Exception("Produto não encontrado");
        
        var produtoInfra = _mapper.Map<DataModels.Produto>(produtoContext);
        _context.Produtos.Remove(produtoInfra);
        _context.SaveChanges();
    }
}