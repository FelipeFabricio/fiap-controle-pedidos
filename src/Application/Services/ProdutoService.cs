using Core.Entities;
using Core.Interfaces.Application.Services;
using Core.Interfaces.Infra.Database;

namespace Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Produto ObtemProdutoPorId(Guid id)
    {
        return _produtoRepository.ObtemProdutoPorId(id);
    }

    public Produto ObtemProdutoPorCategoria(short categoria)
    {
        return _produtoRepository.ObtemProdutoPorCategoria(categoria);
    }

    public IEnumerable<Produto> ObtemTodosProdutos()
    {
        return _produtoRepository.ObtemTodosProdutos();
    }

    public void AdicionaProduto(Produto produto)
    {
        _produtoRepository.AdicionaProduto(produto); 
    }

    public void AtualizaProduto(Produto produto)
    {
        _produtoRepository.AtualizaProduto(produto);
    }

    public void RemoveProduto(Guid id)
    {
        _produtoRepository.RemoveProduto(id);
    }

}