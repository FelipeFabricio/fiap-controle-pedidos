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
        var produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return _mapper.Map<Produto>(produto);
    }

    public IEnumerable<Produto> ObtemProdutosPorCategoria(short categoria)
    {
        var produtos = _context.Produtos.AsNoTracking().Where(p => p.Categoria == categoria);
        return _mapper.Map<IEnumerable<Produto>>(produtos);
    }

    public IEnumerable<Produto> ObtemTodosProdutos()
    {
        var produtos = _context.Produtos.AsNoTracking().AsEnumerable();
        return _mapper.Map<IEnumerable<Produto>>(produtos);
    }

    public Produto AdicionaProduto(Produto produto)
    {
        var produtoInfra = _mapper.Map<DataModels.Produto>(produto);
        _context.Produtos.Add(produtoInfra);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return _mapper.Map<Produto>(produtoInfra);
    }

    public void AtualizaProduto(Produto produto)
    {
        var produtoContext = ObtemProdutoPorId(produto.Id);
        if (produtoContext == null)
            throw new Exception("Produto não encontrado");
        
        var produtoInfra = _mapper.Map<DataModels.Produto>(produto);
        _context.Entry(produtoInfra).State = EntityState.Modified;
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void RemoveProduto(Guid id)
    {
        var produtoContext = ObtemProdutoPorId(id);
        if (produtoContext == null)
            throw new Exception("Produto não encontrado");
        
        var produtoInfra = _mapper.Map<DataModels.Produto>(produtoContext);
        _context.Produtos.Remove(produtoInfra);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}