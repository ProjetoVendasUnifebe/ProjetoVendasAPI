using Vendas.Domain.Entities;
using Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.DTOs;
using Vendas.Domain.Interfaces.Repositories;

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

        public EstoqueProdutoModel BuscarEstoqueProdutoPorId(int idEstoqueProduto)
        {
            return _dbSet.Find(idEstoqueProduto);
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            return _dbSet.Where(x => x.IdProduto == idProduto).ToList();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            return _dbSet.Where(x => x.IdEstoque == idEstoque).ToList();
        }

        public bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto)
        {
            estoqueProduto.DataAtualizacao = DateTime.UtcNow.AddHours(-3);
            _dbSet.Add(estoqueProduto);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarEstoqueProduto(EstoqueProdutoModel estoqueProdutoAtualizado)
        {
            var estoqueProduto = BuscarEstoqueProdutoPorId(estoqueProdutoAtualizado.IdEstoque_Produto);
            if (estoqueProduto == null)
                return "Estoque Produto não encontrado";
            
            estoqueProduto.IdEstoque = estoqueProdutoAtualizado.IdEstoque != 0 ? estoqueProdutoAtualizado.IdEstoque : estoqueProduto.IdEstoque;
            estoqueProduto.IdProduto = estoqueProdutoAtualizado.IdProduto != 0 ? estoqueProdutoAtualizado.IdProduto : estoqueProduto.IdProduto;
            estoqueProduto.Quantidade = estoqueProdutoAtualizado.Quantidade != 0 ? estoqueProdutoAtualizado.Quantidade : estoqueProduto.Quantidade;
            estoqueProduto.DataAtualizacao = DateTime.UtcNow.AddHours(-3);

            _dbSet.Update(estoqueProduto);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Falha ao atualizar o estoque produto";
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