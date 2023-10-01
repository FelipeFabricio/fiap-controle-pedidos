namespace Infra.Database.MySql.DataModels;

public sealed record  Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public IEnumerable<Pedido> Pedidos { get; set; }
}








