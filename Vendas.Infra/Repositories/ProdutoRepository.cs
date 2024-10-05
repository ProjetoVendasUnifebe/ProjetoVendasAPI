using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSet<ProdutoModel> _dbSet;
        public ProdutoRepository(VendasDbContext context) 
        { 
            _dbSet = context.Set<ProdutoModel>();
        }
        public List<ProdutoModel> BuscarProdutos()
        {
            return _dbSet.ToList();
        }
        
    }
}
