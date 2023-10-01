using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySql.DataMappings;

public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable("ItensPedido");
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(p => p.Quantidade).HasColumnType("int").IsRequired();
        builder.Property(p => p.PedidoId).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(p => p.ProdutoId).HasColumnType("uniqueidentifier").IsRequired();
    }
}