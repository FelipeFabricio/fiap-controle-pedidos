using Core.Entities;
using Core.Enums;

namespace Core.Interfaces.Infra.Database;

public interface IProdutoRepository
{
    Produto ObtemProdutoPorId(Guid id);
    Produto ObtemProdutoPorCategoria(CategoriaProduto categoria);
    IEnumerable<Produto> ObtemTodosProdutos();
    void AdicionaProduto(Produto produto);
    void AtualizaProduto(Produto produto);
    void RemoveProduto(Guid id);
}