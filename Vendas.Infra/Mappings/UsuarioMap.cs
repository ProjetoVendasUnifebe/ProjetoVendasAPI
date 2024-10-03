using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("usuario", "comercialize");

            builder.HasKey(x => x.IdUsuario);

            builder.Property(x => x.IdUsuario).HasColumnName("idUsuario").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.NomeUsuario).HasColumnName("nomeUsuario").HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(60)").IsRequired();
        }
    }
}
