using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("usuario", "comercialize");

            builder.HasKey(x => x.IdUsuario);
            builder.HasIndex(x => x.Login).IsUnique();
            

            builder.Property(x => x.IdUsuario).HasColumnName("idUsuario").HasColumnType("int").IsRequired();
            builder.Property(x => x.NomeUsuario).HasColumnName("nomeUsuario").HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.EhAdm).HasColumnName("ehAdm").HasColumnType("int").IsRequired();
            builder.Property(x => x.Login).HasColumnName("login").HasColumnType("varchar(60)").IsRequired();
        }
    }
}
