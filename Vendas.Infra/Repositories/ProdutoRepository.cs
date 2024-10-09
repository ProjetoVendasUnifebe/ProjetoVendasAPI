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

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<ProdutoModel>> BuscarProdutoPorNome(string nome)
        {
            return await _dbSet
                .Where(x => x.NomeProduto.Contains(nome))
                .ToListAsync();
        }

        public async Task AdicionarProduto(ProdutoModel novoProduto)
        {
            await _dbSet.AddAsync(novoProduto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AtualizarProduto(ProdutoModel produtoAtualizado)
        {
            _dbSet.Update(produtoAtualizado);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool RemoverProduto(int id)
        {
            var produto = _dbSet.Find(id);

            if (produto == null) 
                return false;

            _dbSet.Remove(produto);
            _context.SaveChanges();
            return true;//falta salvar a alteração e retornar o resultado correto
        }

    }
}

