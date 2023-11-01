using Core.Enums;

namespace Infra.Database.MySql.DataModels;

public sealed record  Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; } = null!;
    public short Categoria { get; set; }
}