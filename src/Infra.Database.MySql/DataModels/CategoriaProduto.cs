namespace Infra.Database.MySql.DataModels;

public sealed record  CategoriaProduto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
}