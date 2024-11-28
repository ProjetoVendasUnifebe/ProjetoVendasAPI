using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class VendaMap : IEntityTypeConfiguration<VendaModel>
    {
        public void Configure(EntityTypeBuilder<VendaModel> builder)
        {
            builder.ToTable("venda", "comercialize");

            builder.HasKey(x => x.IdVenda);

            builder.HasIndex(x => x.IdUsuario);
            builder.HasOne<VendaModel>()
                   .WithMany()
                   .HasForeignKey(x => x.IdUsuario);
            
            builder.HasIndex(x => x.IdCliente);
            builder.HasOne<VendaModel>()
            .WithMany()
            .HasForeignKey(x => x.IdCliente);

            builder.Property(x => x.IdVenda).HasColumnName("idVenda").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdUsuario).HasColumnName("idUsuario").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdCliente).HasColumnName("idCliente").HasColumnType("int").IsRequired();
            builder.Property(x => x.valor).HasColumnName("valor").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.data_venda).HasColumnName("data_venda").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.forma_pagamento).HasColumnName("forma_pagamento").HasColumnType("varchar(20)").IsRequired();
        }
    }
}