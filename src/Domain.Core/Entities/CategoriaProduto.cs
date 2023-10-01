namespace Core.Entities;

public sealed record  CategoriaProduto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}