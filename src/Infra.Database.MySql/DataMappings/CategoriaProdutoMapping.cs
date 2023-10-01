using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySql.DataMappings;

public class CategoriaProdutoMapping : IEntityTypeConfiguration<CategoriaProduto>
{
    public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
    {
        builder.ToTable("CategoriaProduto");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
    }
}
