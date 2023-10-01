namespace Application.Dtos;

public sealed record CategoriaProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}