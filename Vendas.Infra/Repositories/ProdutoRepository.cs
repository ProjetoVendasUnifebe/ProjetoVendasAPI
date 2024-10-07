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
            return await _dbSet.FirstOrDefaultAsync(x => x.IdProduto == id);
        }

        public async Task<ProdutoModel> BuscarProdutoPorNome(string nome)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.NomeProduto == nome);
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

        public async Task RemoverProduto(int id)
        {
            var produto = await BuscarProdutoPorId(id);
            if (produto != null)
            {
                _dbSet.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
