using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
namespace Vendas.Infra.Context
{
    public class VendasDbContext : DbContext
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
