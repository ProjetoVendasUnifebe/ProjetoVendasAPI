using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class EstoqueProdutoMap : IEntityTypeConfiguration<EstoqueProdutoModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueProdutoModel> builder)
        {
            builder.ToTable("estoque_produto", "comercialize");

            builder.HasKey(x => x.IdEstoque_Produto);

            builder.HasIndex(x => x.IdProduto);
            builder.HasOne<ProdutoModel>()
                   .WithMany()
                   .HasForeignKey(x => x.IdProduto);

            builder.HasIndex(x => x.IdEstoque);
            builder.HasOne<EstoqueModel>()
            .WithMany()
            .HasForeignKey(x => x.IdEstoque);

            builder.Property(x => x.IdEstoque_Produto).HasColumnName("idEstoque_Produto").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdProduto).HasColumnName("idProduto").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdEstoque).HasColumnName("idEstoque").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnName("data_atualizacao").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasColumnType("int").IsRequired();
        }
    }
}