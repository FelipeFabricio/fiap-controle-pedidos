using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySql.Context;

public class ControlePedidosContext : DbContext
{
    public ControlePedidosContext(DbContextOptions<ControlePedidosContext> options) : base(options)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CategoriaProduto> CategoriasProduto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlePedidosContext).Assembly);
    }
}