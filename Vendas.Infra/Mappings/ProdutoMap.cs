using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("produto", "comercialize");

            builder.HasKey(x => x.IdProduto);

            builder.Property(x => x.IdProduto).HasColumnName("idProduto").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.NomeProduto).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").HasColumnType("double").IsRequired();
        }
    }
}