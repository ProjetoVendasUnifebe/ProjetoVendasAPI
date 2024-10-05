using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSet<ClienteModel> _dbSet;
        public ClienteRepository(VendasDbContext context) 
        { 
            _dbSet = context.Set<ClienteModel>();
        }
        public List<ClienteModel> BuscarClientes()
        {
            return _dbSet.ToList();
        }
    }
}