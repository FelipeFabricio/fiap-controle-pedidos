using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySql.DataMappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Preco).HasPrecision(10, 2).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(500).IsRequired();
        builder.Property(p => p.ImagemUrl).HasMaxLength(2000).IsRequired();
        builder.Property(p => p.Categoria).IsRequired();
    }
}
