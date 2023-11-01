using Core.Entities;
using Core.Enums;

namespace Core.Interfaces.Infra.Database;

public interface IProdutoRepository
{
    Produto ObtemProdutoPorId(Guid id);
    IEnumerable<Produto> ObtemProdutosPorCategoria(short categoria);
    IEnumerable<Produto> ObtemTodosProdutos();
    Produto AdicionaProduto(Produto produto);
    void AtualizaProduto(Produto produto);
    void RemoveProduto(Guid id);
}