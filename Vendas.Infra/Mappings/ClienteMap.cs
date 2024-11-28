using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entities;

namespace Vendas.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.ToTable("cliente", "comercialize");

            builder.HasKey(x => x.IdCliente);

            builder.HasIndex(x => x.IdEndereco);

            // builder.HasOne(x => x.Endereco)
            builder.HasOne<EnderecoModel>()
                   .WithMany()
                   .HasForeignKey(x => x.IdEndereco);

            builder.Property(x => x.IdCliente).HasColumnName("idCliente").HasColumnType("int").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("varchar(15)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Sexo).HasColumnName("sexo").HasColumnType("varchar(1)").IsRequired();
            builder.Property(x => x.IdEndereco).HasColumnName("idEndereco").HasColumnType("int").IsRequired();
            
        }
    }
}