using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(x => x.IdEndereco);

            builder.Property(x => x.IdEndereco).HasColumnName("idEndereco").HasColumnType("int").IsRequired();
            builder.Property(x => x.Pais).HasColumnName("pais").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Estado).HasColumnName("estado").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnName("cidade").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cep).HasColumnName("cep").HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Bairro).HasColumnName("bairro").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Rua).HasColumnName("rua").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasColumnType("int").IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasColumnType("varchar(100)").IsRequired();
        }
        
    }
}