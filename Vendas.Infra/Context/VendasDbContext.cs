using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
namespace Vendas.Infra.Context
{
    public class VendasDbContext : DbContext
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
