using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DbSet<VendaModel> _dbSet;
        public VendaRepository(VendasDbContext context) 
        { 
            _dbSet = context.Set<VendaModel>();
        }
        public List<VendaModel> BuscarVendas()
        {
            return _dbSet.ToList();
        }
        
    }
}
