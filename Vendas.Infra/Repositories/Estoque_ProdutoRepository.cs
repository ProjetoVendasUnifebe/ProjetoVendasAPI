using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.DTOs;

namespace Vendas.Infra.Repositories
{
    public class Estoque_ProdutoRepository : IEstoque_ProdutoRepository
    {

        private readonly DbSet<EstoqueProdutoModel> _dbSet;
        private readonly VendasDbContext _context;

        public Estoque_ProdutoRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<EstoqueProdutoModel>();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProduto()
        {
            return _dbSet.ToList();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            return _dbSet.Where(x => x.IdProduto == idProduto).ToList();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            return _dbSet.Where(x => x.IdEstoque == idEstoque).ToList();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorQuantidade(int quantidade)
        {
            return _dbSet.Where(x => x.Quantidade == quantidade).ToList();
        }
        public bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto)
        {
            estoqueProduto.DataAtualizacao = DateTime.UtcNow.AddHours(-3);
            _dbSet.Add(estoqueProduto);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarEstoqueProduto(int id, Estoque_ProdutoDTO estoqueProdutoAtualizado)
        {
            var estoque_produto = _dbSet.Find(id);

            if(estoque_produto == null)
                return "Estoque Produto não encontrado";

            estoque_produto.IdProduto = estoqueProdutoAtualizado.IdProduto;
            estoque_produto.IdEstoque = estoqueProdutoAtualizado.IdEstoque;
            estoque_produto.Quantidade = estoqueProdutoAtualizado.Quantidade;
            estoque_produto.DataAtualizacao = DateTime.UtcNow.AddHours(-3);
            
            _dbSet.Update(estoque_produto);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro interno do servidor";
        }

        public bool RemoverEstoqueProduto(int idEstoqueProduto)
        {
            var estoqueProduto = _dbSet.Find(idEstoqueProduto);
            
            if(estoqueProduto == null)
                return false;
            _dbSet.Remove(estoqueProduto);
            return _context.SaveChanges() > 0;
        }
    }
}