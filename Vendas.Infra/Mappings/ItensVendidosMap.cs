using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class ItensVendidosMap : IEntityTypeConfiguration<ItensVendidosModel>
    {
        public void Configure(EntityTypeBuilder<ItensVendidosModel> builder)
        {
            builder.ToTable("itensVendidos", "comercialize");

            builder.HasKey(x => x.IdItensVendidos);

            builder.HasIndex(x => x.IdVenda);
            builder.HasOne<VendaModel>()
            .WithMany()
            .HasForeignKey(x => x.IdVenda);

            builder.HasIndex(x => x.IdProduto);
            builder.HasOne<ProdutoModel>()
                    .WithMany()
                    .HasForeignKey(x => x.IdProduto);
                    
            builder.Property(x => x.IdItensVendidos).HasColumnName("idItensVendidos").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdVenda).HasColumnName("idVenda").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdProduto).HasColumnName("idProduto").HasColumnType("int").IsRequired();
            builder.Property(x => x.QtdVendida).HasColumnName("qtdVendida").HasColumnType("int").IsRequired();
        }
    }
}