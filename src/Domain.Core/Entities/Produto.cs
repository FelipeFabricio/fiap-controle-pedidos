 using Core.Enums;

namespace Core.Entities;

public sealed record  Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; }
    public CategoriaProduto Categoria { get; set; }
}