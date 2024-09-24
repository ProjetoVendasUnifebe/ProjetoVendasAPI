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
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("usuarioId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("usuarioNome").HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.CPF).HasColumnName("usuarioCPF").HasColumnType("varchar(14)").IsRequired();
            builder.Property(x => x.Cargo).HasColumnName("usuarioCargo").HasColumnType("varchar(60)").IsRequired();

        }
            
    }
}
