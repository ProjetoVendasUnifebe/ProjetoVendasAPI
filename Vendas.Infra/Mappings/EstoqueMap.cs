using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class EstoqueMap : IEntityTypeConfiguration<EstoqueModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueModel> builder)
        {
            builder.ToTable("estoque", "comercialize");

            builder.HasKey(x => x.IdEstoque);

            builder.Property(x => x.IdEstoque).HasColumnName("idEstoque").HasColumnType("int").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Capacidade).HasColumnName("capacidade").HasColumnType("int").IsRequired();
        }
    }
}