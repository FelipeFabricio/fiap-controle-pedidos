namespace Infra.Database.MySql.DataModels;

public sealed record  Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; } = null!;
    public Guid CategoriaId { get; set; }
    
    //TODO: Precisamos realmente ter uma tabela só paras as categorias? Não poderia ser um enum?
    public CategoriaProduto Categoria { get; set; }
}