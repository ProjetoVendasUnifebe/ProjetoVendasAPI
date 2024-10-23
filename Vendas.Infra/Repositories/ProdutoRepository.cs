using Microsoft.EntityFrameworkCore;
using Vendas.Domain.DTOs;
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
            return _dbSet.Where(x => EF.Functions.Like(x.NomeProduto.ToLower(), $"%{nome.ToLower()}%")).ToList();
        }

        public bool AdicionarProduto(ProdutoModel novoProduto)
        {
            _dbSet.Add(novoProduto);
            return _context.SaveChanges() > 0;

        }

        public string AtualizarProduto(ProdutoModel produtoAtualizado)
        {
            var produto = BuscarProdutoPorId(produtoAtualizado.IdProduto);
            if (produto == null)
                return "Produto não encontrado";
            produto.NomeProduto = string.IsNullOrEmpty(produtoAtualizado.NomeProduto) ? produto.NomeProduto : produtoAtualizado.NomeProduto;
            produto.Valor = produtoAtualizado.Valor != 0 ? produtoAtualizado.Valor : produto.Valor;
            produto.Descricao = string.IsNullOrEmpty(produtoAtualizado.Descricao) ? produto.Descricao : produtoAtualizado.Descricao;

            _dbSet.Update(produto);
            if(_context.SaveChanges() > 0)
                return string.Empty;
            
            return "Falha ao atualizar o produto";
        }

        public bool RemoverProduto(int id)
        {
            var produto = _dbSet.Find(id);

            if (produto == null) 
                return false;

            _dbSet.Remove(produto);
            return _context.SaveChanges() > 0;
        }

    }
}

