using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSet<ProdutoModel> _dbSet;
        private readonly VendasDbContext _context;

        public ProdutoRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProdutoModel>();
        }

        public List<ProdutoModel> BuscarProdutos()
        {
            return _dbSet.ToList();
        }

        public ProdutoModel BuscarProdutoPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<ProdutoModel> BuscarProdutoPorNome(string nome)
        {
            return _dbSet
                .Where(x => x.NomeProduto.Contains(nome))
                .ToList();
        }

        public bool AdicionarProduto(ProdutoModel novoProduto)
        {
            _dbSet.Add(novoProduto);
            return _context.SaveChanges() > 0;

        }

        public bool AtualizarProduto(ProdutoModel produtoAtualizado)
        {
            _dbSet.Update(produtoAtualizado);
            return _context.SaveChanges() > 0;
        }

        public bool RemoverProduto(int id)
        {
            var produto = _dbSet.Find(id);

            if (produto == null) 
                return false;

            _dbSet.Remove(produto);
            _context.SaveChanges();
            return true;
        }

    }
}

