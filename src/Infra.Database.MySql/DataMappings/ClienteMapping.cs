using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySql.DataMappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        //TODO: Verificar campos obrigatórios
        builder.ToTable("Clientes");
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(p => p.Nome).HasMaxLength(100);
        builder.Property(p => p.CPF).HasMaxLength(11);
        builder.Property(p => p.Email).HasMaxLength(100);
    }
}