using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly DbSet<EstoqueModel> _dbSet;
        private readonly VendasDbContext _context;

        public EstoqueRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<EstoqueModel>();
        }

        public List<EstoqueModel> BuscarEstoques()
        {
            return _dbSet.ToList();
        }

        public EstoqueModel BuscarEstoquePorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque)
        {
            return _dbSet
                .Where(x => x.Nome.Contains(nomeEstoque))
                .ToList();
        }

        public bool AdicionarEstoque(EstoqueModel estoque)
        {
            _dbSet.Add(estoque);
            return _context.SaveChanges() > 0;
        }

        public bool AtualizarEstoque(EstoqueModel estoque)
        {
            _dbSet.Update(estoque);
            return _context.SaveChanges() > 0;
        }

        public bool RemoverEstoque(int id)
        {
            var estoque = _dbSet.Find(id);

            if (estoque == null) 
                return false;

            _dbSet.Remove(estoque);
            _context.SaveChanges();
            return true;
        }
    }
}

