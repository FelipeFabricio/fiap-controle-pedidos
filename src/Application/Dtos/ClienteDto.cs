namespace Application.Dtos;

public sealed record ClienteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public IEnumerable<PedidoDto> Pedidos { get; set; }
}








